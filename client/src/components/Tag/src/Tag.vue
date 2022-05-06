<template>
  <nav class="section main-navbar">
    <ul class="menu">
      <li class="menu-item" :class="{ 'menu-item-active': current === item.icon }" v-for="item in items" :key="item.icon">
        <a :href="item.url" :target="item.target || '_self'">
          <Icon :type="item.icon" />
          {{ item.name }}
        </a>
      </li>
    </ul>
  </nav>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Icon from '@/components/Icon'

export default defineComponent({
  name: 'Tag',
  components: {
    Icon
  },
  setup() {
    return {
    }
  }
})
</script>

<style scoped>
</style>
