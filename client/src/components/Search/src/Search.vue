<template>
  <div class="ts-search" :class="{ show: show }">
    <header class="ts-search-bar">
      <label class="search-loading" v-if="!loading">
        <svg viewBox="0 0 38 38" stroke="currentColor" stroke-opacity="0.5">
          <g fill="none" fill-rule="evenodd">
            <g transform="translate(1 1)" stroke-width="2">
              <circle stroke-opacity="0.3" cx="18" cy="18" r="18" />
              <path d="M36 18c0-9.94-8.06-18-18-18">
                <animateTransform attributeName="transform" type="rotate" from="0 18 18" to="360 18 18" dur="1s" repeatCount="indefinite" />
              </path>
            </g>
          </g>
        </svg>
      </label>
      <label class="ts-search-label" for="search-input" v-else>
        <svg viewBox="0 0 20 20">
          <path
            d="M14.386 14.386l4.0877 4.0877-4.0877-4.0877c-2.9418 2.9419-7.7115 2.9419-10.6533 0-2.9419-2.9418-2.9419-7.7115 0-10.6533 2.9418-2.9419 7.7115-2.9419 10.6533 0 2.9419 2.9418 2.9419 7.7115 0 10.6533z"
            stroke="currentColor"
            fill="none"
            fill-rule="evenodd"
            stroke-linecap="round"
            stroke-linejoin="round"
          />
        </svg>
      </label>

      <input class="ts-search-input" autocomplete="off" spellcheck="false" autofocus="true" placeholder="请输入关键字" maxlength="32" type="search" />

      <button class="ts-search-reset" type="reset" title="清空" hidden>
        <svg width="20" height="20" viewBox="0 0 20 20">
          <path d="M10 10l5.09-5.09L10 10l5.09 5.09L10 10zm0 0L4.91 4.91 10 10l-5.09 5.09L10 10z" stroke="currentColor" fill="none" fill-rule="evenodd" stroke-linecap="round" stroke-linejoin="round" />
        </svg>
      </button>
    </header>

    <main class="ts-search-content">
      <div class="ts-search-empty">
        <p>未找需要搜索的内容</p>
      </div>
    </main>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from 'vue'

export default defineComponent({
  name: 'Search',
  setup() {
    const show = ref(false)
    const loading = ref(true)

    onMounted(() => {
      show.value = true
    })

    return {
      show,
      loading
    }
  }
})
</script>

<style lang="less" scope>
.ts-search {
  z-index: 9;
  width: 520px;
  position: fixed;
  border-radius: 8px;
  box-sizing: border-box;
  left: calc(50vw - 260px);
  padding: var(--theme-gutter-size);
  transform: translate3d(0, -100%, 0);
  background-color: var(--theme-bg-color);
  transition: transform 0.2s ease-in-out;
  backdrop-filter: blur(50px) saturate(150%);
  box-shadow: inset 1px 1px 0 0 hsla(0, 0%, 100%, 0.5), 0 3px 8px 0 #585c62;
}

.show {
  transform: translate3d(0, 50px, 0);
  transition: transform 0.2s ease-in-out;
}

.ts-search-bar {
  width: 100%;
  height: 50px;
  display: flex;
  padding: 0 12px;
  align-items: center;
  border-radius: 4px;
  position: relative;
  box-sizing: border-box;
  box-shadow: inset 0 0 0 2px var(--theme-primary-color);

  .search-loading {
    color: var(--theme-primary-color);
    svg {
      width: 20px;
      height: 20px;
    }
  }

  .ts-search-label {
    display: flex;
    align-items: center;
    justify-content: center;
    color: var(--theme-primary-color);

    svg {
      width: 22px;
      height: 22px;
    }
  }

  .ts-search-input {
    flex: 1;
    border: 0;
    width: 80%;
    height: 100%;
    outline: none;
    font-size: 1.2rem;
    appearance: none;
    padding: 0 0 0 8px;
    background: transparent;
    color: var(--theme-secondary-color);
  }
}

.ts-search-empty {
  text-align: center;
  color: var(--theme-text-color);
}
</style>
