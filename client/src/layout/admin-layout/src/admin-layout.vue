<template>
  <el-container class="layout">
    <el-aside class="aside">
      <el-scrollbar>
        <el-menu :default-openeds="['Article']">
          <el-sub-menu index="Article">
            <template #title>
              <el-icon><document /></el-icon>
              博文管理
            </template>

            <el-menu-item index="ArticleCategory">分组管理</el-menu-item>
            <el-menu-item index="ArticleTag">标签管理</el-menu-item>
          </el-sub-menu>

          <el-menu-item index="Todo">
            <template #title>
              <icon type="todo" class="ts-icon" />
              待办管理
            </template>
          </el-menu-item>

          <el-menu-item index="Album">
            <template #title>
              <icon type="album" class="ts-icon" />
              相册管理
            </template>
          </el-menu-item>

          <el-sub-menu index="Visual">
            <template #title>
              <el-icon><data-analysis /></el-icon>
              统计分析
            </template>

            <el-menu-item index="VisualArticle">博文分析</el-menu-item>
            <el-menu-item index="VisualAlbum">相册分析</el-menu-item>
            <el-menu-item index="VisualVisitor">流量分析</el-menu-item>
          </el-sub-menu>
        </el-menu>
      </el-scrollbar>
    </el-aside>

    <el-container>
      <el-header>
        <el-row>
          <el-col :span="16">
            <el-breadcrumb separator="/">
              <el-breadcrumb-item :to="{ path: '/' }">homepage</el-breadcrumb-item>
              <el-breadcrumb-item><a href="/">promotion management</a></el-breadcrumb-item>
              <el-breadcrumb-item>promotion list</el-breadcrumb-item>
              <el-breadcrumb-item>promotion detail</el-breadcrumb-item>
            </el-breadcrumb>
          </el-col>
          <el-col :span="8">
            <div class="toolbar">
              <span>{{ user.name }} </span>
              <el-dropdown>
                <el-icon><setting /></el-icon>
                <template #dropdown>
                  <el-dropdown-menu>
                    <el-dropdown-item>信息</el-dropdown-item>
                    <el-dropdown-item>登出</el-dropdown-item>
                  </el-dropdown-menu>
                </template>
              </el-dropdown>
            </div>
          </el-col>
        </el-row>
      </el-header>
      <el-main>
        <router-view />
      </el-main>
    </el-container>
  </el-container>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import { Document, Message, Setting, DataAnalysis, Menu as IconMenu } from '@element-plus/icons-vue'
import Icon from '@/components/Icon/src/Icon.vue'

export default defineComponent({
  name: 'AdminLayout',
  components: {
    Icon,
    Setting,
    Message,
    IconMenu,
    Document,
    DataAnalysis
  },
  setup() {
    const user = {
      name: '徐瑞'
    }

    return {
      user
    }
  }
})
</script>

<style lang="less">
.layout {
  user-select: none;
  height: 100vh !important;
  border: 1px solid #eee;

  .layout-aside {
    width: 200px;
    background-color: rgb(238, 241, 246);
  }

  .el-header {
    position: relative;
    color: var(--el-text-color-primary);
  }

  .el-aside {
    width: 240px;
    color: var(--el-text-color-primary);
    background: #fff !important;
    border-right: solid 1px #e6e6e6;
    box-sizing: border-box;
  }

  .el-menu {
    border-right: none;
  }

  .el-main {
    padding: 10px;
    background-color: rgb(165, 165, 165);
  }

  .toolbar{
    text-align: right;
  }
}

.ts-icon {
  margin-top: -0.1em;
  font-size: 1.25em !important;
}
</style>
