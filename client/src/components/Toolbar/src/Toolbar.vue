<template>
  <nav class="toolbar">
    <div class="toolbar-button" :class="{ expanded: expanded }" @click="handleExpand">
      <Icon type="plus" style="margin-right: 0" />
    </div>

    <span class="go-top" :class="{ expanded: expanded }" title="返回顶部" @click="handleGoTop">
      <Icon type="angle-up" />
    </span>

    <span class="switch-theme" title="主题模式" :class="{ expanded: expanded }" @click="expandedTheme = !expandedTheme">
      <Icon type="theme" />
    </span>

    <span class="catalog" :class="{ expanded: expanded, disabled: true }" title="大纲">
      <Icon type="list" />
    </span>

    <div class="theme-panel" :class="{ 'expanded-theme': expandedTheme }">
      <div class="title">颜色主题</div>
      <div>
        <button data-theme="default" style="color: #999; background: #999" title="亚克力"></button>
        <button data-theme="highlight" style="color: #fff; background: #fff" title="高亮"></button>
        <button data-theme="dark" style="color: #000; background: #000" title="夜间"></button>
      </div>
    </div>
  </nav>
</template>

<script lang="ts">
import { defineComponent, ref, unref } from 'vue'
import Icon from '@/components/Icon'

export default defineComponent({
  name: 'Toolbar',
  components: {
    Icon
  },
  setup() {
    const expanded = ref(true)
    const expandedTheme = ref(false)

    const handleGoTop = () => {
      scrollTo(0, 0)
    }

    const handleExpand = () => {
      expanded.value = !expanded.value
      if (!unref(expanded)) {
        expandedTheme.value = false
      }
    }

    return {
      expanded,
      expandedTheme,

      handleGoTop,
      handleExpand
    }
  }
})
</script>

<style lang="less" scoped>
.svg-icon {
  margin-right: 0 !important;
}

.toolbar {
  right: 30px;
  bottom: 30px;
  width: 45px;
  height: 45px;
  z-index: 10;
  position: fixed;

  .toolbar-button {
    z-index: 1;
    color: var(--theme-color);
    font-size: 26px;
    width: inherit;
    height: inherit;
    cursor: pointer;
    text-align: center;
    line-height: 46px;
    border-radius: 50%;
    position: relative;
    transition: all 0.35s ease-in-out;
    background: var(--theme-danger-color);
    box-shadow: 0 2px 4px 1px rgba(5, 5, 5, 0.3);
  }

  span {
    opacity: 0;
    z-index: 0;
    width: 35px;
    height: 35px;
    cursor: pointer;
    line-height: 35px;
    right: 0;
    bottom: 0;
    position: absolute;
    text-align: center;
    border-radius: 4px;
    transition: all 0.3s ease;
    background-color: var(--theme-color);
    box-shadow: 0 2px 4px 1px rgb(0 0 0 / 20%);
  }

  span:hover {
    color: var(--theme-color);
    background-color: var(--theme-danger-color);
  }

  span.disabled {
    cursor: auto;
    color: var(--theme-text-color) !important;
    background-color: var(--theme-secondary-color) !important;
  }

  span.expanded {
    opacity: 1;
  }

  .toolbar-button.expanded {
    transform: rotate(-135deg);
  }

  .go-top.expanded {
    transform: translate3d(0, -200%, 0);
  }

  .switch-theme.expanded {
    transform: translate3d(-140%, -140%, 0);
  }

  .catalog.expanded {
    transform: translate3d(-200%, 0, 0);
  }
}

.theme-panel {
  width: 160px;
  height: auto;
  padding: 25px;
  position: fixed;
  user-select: none;
  left: calc(50% - 105px);
  text-align: center;
  border-radius: 8px;
  transform: translate3d(0, 50%, 0);
  background-color: var(--theme-bg-color);
  transition: transform 0.2s ease-in-out;
  backdrop-filter: blur(10px) saturate(100%);
  box-shadow: 0 2px 4px 1px rgba(0, 0, 0, 0.2);

  .title {
    font-size: 17px;
    margin-bottom: 0.35em;
    color: var(--theme-text-color);
  }

  button {
    z-index: 1;
    outline: none;
    margin: 0.55em;
    cursor: pointer;
    border: 2px solid;
    position: relative;
    width: calc(2.8em);
    height: calc(2.8em);
    border-radius: 0.42em;
    justify-self: center;
    box-sizing: border-box;
    background: transparent;
  }

  button:hover {
    border-color: var(--theme-primary-color);
  }
}

.expanded-theme {
  transform: translate3d(0, -100%, 0);
}
</style>
