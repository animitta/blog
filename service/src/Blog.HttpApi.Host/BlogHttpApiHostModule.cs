using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.SwaggerUI;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Blog.DbMigrator;
using Blog.EntityFrameworkCore;

namespace Blog
{
    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(AbpAspNetCoreSerilogModule))]
    [DependsOn(typeof(AbpAspNetCoreAuthenticationJwtBearerModule))]
    [DependsOn(typeof(BlogHttpApiModule))]
    [DependsOn(typeof(BlogFacilitiesModule))]
    [DependsOn(typeof(BlogApplicationModule))]
    [DependsOn(typeof(BlogEntityFrameworkCoreModule))]
    public class BlogHttpApiHostModule : AbpModule
    {
        private const string DefaultCorsPolicyName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            var configuration = context.Services.GetConfiguration();
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            #region 注入语言资源
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            });
            #endregion

            #region 注入核心路由
            services.AddControllersWithViews();
            services.AddRouting(options => options.LowercaseUrls = true);
            #endregion

            #region 注入跨域地址
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    var origins = configuration["App:CorsOrigins"]
                        .Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .Select(o => o.RemovePostFix("/"))
                        .ToArray();

                    builder.WithOrigins(origins)
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
            #endregion

            #region 注入接口文档
            services.AddSwaggerGen(
                options =>
                {
                    var groups = new[] { "client", "open-api" };
                    options.CustomSchemaIds(x => x.FullName);
                    options.SwaggerDoc(groups[0], new OpenApiInfo { Title = "客户端", Version = "v1" }); ;
                    options.SwaggerDoc(groups[1], new OpenApiInfo { Title = "开放接口", Version = "v1" });

                    // 分组模式
                    options.DocInclusionPredicate((docName, description) =>
                    {
                        var groupName = description.GroupName ?? groups[0];
                        if (description.RelativePath.Contains("/abp/"))
                        {
                            return false;
                        }

                        if (!groups.Contains(groupName))
                        {
                            groupName = groups[0];
                        }

                        return docName == groupName;
                    });

                    // 安全模式定义
                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Description = "请输入Bearer token"
                    });

                    // 定义全局使用的安全模式
                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference()
                                {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                }
                            },
                            Array.Empty<string>()
                        }
                    });

                    #region 处理继承XML注释
                    var xmlFiles = new string[]
                    {
                        Path.Combine(AppContext.BaseDirectory, "Blog.Domain.xml"),
                        Path.Combine(AppContext.BaseDirectory, "Blog.Domain.Shared.xml"),
                        Path.Combine(AppContext.BaseDirectory, "Blog.Application.xml"),
                        Path.Combine(AppContext.BaseDirectory, "Blog.Application.Contracts.xml"),
                        Path.Combine(AppContext.BaseDirectory, "Blog.HttpApi.xml"),
                        Path.Combine(AppContext.BaseDirectory, "Blog.HttpApi.Host.xml"),
                    };

                    var members = new Dictionary<string, XElement>();
                    var xmlDocs = xmlFiles.Select(xmlFile => XDocument.Load(xmlFile)).ToList();

                    // 查找所有非inheritdoc标记
                    foreach (var xmlDoc in xmlDocs)
                    {
                        var memberElements = xmlDoc.XPathSelectElements("/doc/members/member[@name and not(inheritdoc)]");
                        foreach (var memberElement in memberElements)
                        {
                            members.Add(memberElement.Attribute("name").Value, memberElement);
                        }
                    }

                    // 将inheritdoc标记替换为实际标记
                    foreach (var xmlDoc in xmlDocs)
                    {
                        var memberElements = xmlDoc.XPathSelectElements("/doc/members/member[inheritdoc]");
                        foreach (var memberElement in memberElements)
                        {
                            var inheritdocElement = memberElement.Element("inheritdoc");
                            var name = memberElement.Attribute("name").Value;
                            var cref = inheritdocElement.Attribute("cref")?.Value;

                            if (!string.IsNullOrWhiteSpace(cref))
                            {
                                if (members.TryGetValue(cref, out var realDocMember))
                                {
                                    inheritdocElement.Parent.ReplaceNodes(realDocMember.Nodes());
                                }
                            }
                            else
                            {
                                name = name.ReplaceFirst("Blog.Users.", "Blog.Users.I");
                                if (members.TryGetValue(name, out var realDocMember))
                                {
                                    inheritdocElement.Parent.ReplaceNodes(realDocMember.Nodes());
                                }
                            }
                        }

                        options.IncludeXmlComments(() => new XPathDocument(xmlDoc.CreateReader()), true);
                    }
                    #endregion
                });
            #endregion

            #region 注入虚拟文件
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                if (hostingEnvironment.IsDevelopment())
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<BlogDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Blog.Domain.Shared"));
                }
            });
            #endregion

            #region 注入身份认证
            var schema = JwtBearerDefaults.AuthenticationScheme;
            context.Services.AddAuthentication(schema)
                .AddJwtBearer(schema, options =>
                 {
                     options.SaveToken = true;
                     options.RequireHttpsMetadata = false;

                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = true,
                         ValidateLifetime = true,
                         ValidateAudience = false,
                         RequireExpirationTime = false,
                         ValidateIssuerSigningKey = true,
                         ValidIssuer = "thinkershare.com",
                         ValidAudience = "blog.thinkershare.com",
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("TXJic1dlYkFwaUxlc3Nvck1vZHVsZUAyMDIwX2RsJlNlY3JldA=="))
                     };

                     // 兼容某些不支持在WebSocket种添加自定义HEAD的客户端
                     options.Events = new JwtBearerEvents
                     {
                         OnMessageReceived = context =>
                         {
                             var accessToken = context.Request.Query["access_token"];
                             var path = context.HttpContext.Request.Path;
                             if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/signalr-hubs"))
                             {
                                 context.Token = accessToken;
                             }
                             return Task.CompletedTask;
                         }
                     };
                 });
            #endregion

            #region 注入契约路由
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(BlogApplicationModule).Assembly);
            });
            #endregion
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAbpRequestLocalization();
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/error");
            }

            app.UseCorrelationId();
            app.UseDefaultFiles();
            app.UseStaticFiles(GetStaticFileOptions());

            app.UseRouting();
            app.UseCors(DefaultCorsPolicyName);

            app.UseAuthentication();
            app.UseJwtTokenMiddleware();
            app.UseUnitOfWork();
            app.UseAuthorization();

            app.UseAuditing();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.DefaultModelsExpandDepth(2);
                options.DocExpansion(DocExpansion.None);

                options.SwaggerEndpoint($"/swagger/client/swagger.json", "客户端组");
                options.SwaggerEndpoint($"/swagger/open-api/swagger.json", "开放API组");
            });

            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            static StaticFileOptions GetStaticFileOptions()
            {
                var mimeContentTypeProvider = new FileExtensionContentTypeProvider();
                mimeContentTypeProvider.Mappings[".log"] = "application/octet-stream";
                mimeContentTypeProvider.Mappings[".json"] = "application/octet-stream";

                return new StaticFileOptions
                {
                    ContentTypeProvider = mimeContentTypeProvider
                };
            }
        }
    }
}
