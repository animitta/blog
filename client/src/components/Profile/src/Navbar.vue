<template>
  <nav class="section navbar">
    <ul class="menu">
      <li class="menu-item" :class="{ 'menu-item-active': current === item.icon }" v-for="item in items" :key="item.icon" @click.capture.stop="current = item.icon">
        <a href="#" :target="item.target || '_self'">
          <Icon :type="item.icon" />
          {{ item.name }}
        </a>
      </li>
    </ul>
  </nav>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue'
import Icon from '@/components/Icon'
import { MenuItem } from './type'

export default defineComponent({
  name: 'Navbar',
  components: {
    Icon
  },
  setup() {
    const items: MenuItem[] = [
      {
        icon: 'manage',
        name: '管理',
        url: '/'
      },
      {
        icon: 'home',
        name: '主页',
        url: '/'
      },
      {
        icon: 'archive',
        name: '归档',
        url: '/'
      },
      {
        icon: 'category',
        name: '分组',
        url: '/'
      },
      {
        icon: 'tags',
        name: '标签',
        url: '/'
      },
      {
        icon: 'todo',
        name: '待办',
        url: '/'
      },
      {
        icon: 'album',
        name: '相册',
        url: '/'
      },
      {
        icon: 'search',
        name: '搜索',
        url: '/'
      },
      {
        icon: 'about',
        name: '关于',
        url: '/'
      },
      {
        icon: 'timeline',
        name: '时间线',
        url: '/'
      },
      {
        icon: 'visual',
        name: '可视化',
        url: '/'
      },
      {
        icon: 'rss',
        name: 'RSS订阅',
        url: '/'
      },
      {
        icon: 'github',
        name: 'GITHUB',
        target: '_blank',
        url: 'https://github.com/thinkershare'
      }
    ]

    const current = ref('home')

    return {
      items,
      current: current
    }
  }
})
</script>

<style scoped>
.navbar {
  font-size: 14px;
  min-width: 240px;
  background-color: var(--theme-bg-color);
  backdrop-filter: blur(120px) saturate(100%);
}

.menu {
  margin: 0;
  padding: 18px 0;
  list-style: none;
}

.menu-item {
  cursor: pointer;
  padding: 8px 18px;
  position: relative;
}

.menu-item-active,
.menu-item:hover {
  background-color: var(--theme-active-color);
}

.menu-item-active::after,
.menu-item:hover::after {
  content: ' ';
  top: 50%;
  width: 6px;
  height: 6px;
  right: 20px;
  margin-top: -3px;
  border-radius: 50%;
  position: absolute;
  background-color: var(--theme-secondary-color);
}

.menu-item a {
  display: block;
  text-decoration: none;
  color: var(--theme-text-color);
}

.svg-icon {
  margin-right: 0.4em;
}
</style>
