using System;
using System.IO;
using System.Linq;

namespace Blog.Helpers
{
    /// <summary>
    /// 路径帮助类
    /// </summary>
    public static class PathHelper
    {
        /// <summary>
        /// 获取解决方案所在的目录(.sln文件)
        /// </summary>
        /// <returns>解决方案文件所在路径</returns>
        public static string GetSolutionFolderPath()
        {
            var currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (Directory.GetParent(currentDirectory.FullName) != null)
            {
                currentDirectory = Directory.GetParent(currentDirectory.FullName);

                if (Directory.GetFiles(currentDirectory.FullName).Any(f => f.EndsWith(".sln")))
                {
                    return currentDirectory.FullName;
                }
            }

            return null;
        }

        /// <summary>
        /// 获取EntityFramework项目所在文件夹
        /// </summary>
        /// <returns>迁移执行项目路径或者default(string)</returns>
        public static string GetEntityFrameworkCoreProjectFolderPath()
        {
            var slnDirectoryPath = GetSolutionFolderPath();
            if (slnDirectoryPath == null)
            {
                throw new Exception("解决方案(.sln)目录未找到!");
            }

            var srcDirectoryPath = Path.Combine(slnDirectoryPath, "src");
            return Directory.GetDirectories(srcDirectoryPath).FirstOrDefault(d => d.EndsWith(".EntityFrameworkCore"));
        }
    }
}
