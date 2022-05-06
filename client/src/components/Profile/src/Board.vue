<template>
  <nav class="section main-board">
    <p class="author text-main text-center" itemprop="name">{{ author }}</p>

    <div class="text-center">
      <Frame size="3px" color="#eee" radius="15%">
        <img src="/logo.png" width="120" />
      </Frame>
    </div>

    <p class="profile text-center text-secondary" itemprop="profile">{{ profile }}</p>

    <div class="labels text-center">
      <div>
        <span class="text-main">{{ articleCount }}</span>
        <span class="text-secondary">博文</span>
      </div>

      <div>
        <span class="text-main">{{ categoryCount }}</span>
        <span class="text-secondary">分组</span>
      </div>

      <div>
        <span class="text-main">{{ tagCount }}</span>
        <span class="text-secondary">标签</span>
      </div>
    </div>
  </nav>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import { Frame } from '@/components/Frame'

export default defineComponent({
  name: 'Footer',
  components: {
    Frame
  },
  setup() {
    return {
      tagCount: 80,
      categoryCount: 28,
      articleCount: 123,
      author: 'XuRui',
      profile: '保持运动, 保持思考, 保持分享'
    }
  }
})
</script>

<style scoped>
.main-board {
  min-width: 180px;
  padding: 10px 30px 30px;
  background-color: var(--theme-bg-color);
  backdrop-filter: blur(120px) saturate(100%);
}

.author {
  margin: 0;
  line-height: 36px;
}

.labels {
  display: flex;
  flex-direction: row;
}

.labels div {
  flex-grow: 1;
  border-right: 1px solid #eee;
}

.labels div:last-child {
  border-width: 0;
}

.labels span {
  display: block;
  line-height: 1.5;
}
</style>
