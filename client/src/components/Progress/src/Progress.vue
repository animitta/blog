<template>
  <div class="ts-progress" :style="style">
    <div class="ts-progress-inner" :style="innerStyle"></div>
  </div>
</template>

<script lang="ts">
import { defineComponent, toRefs, computed } from 'vue'

export default defineComponent({
  props: {
    value: {
      type: Number,
      default: 100
    },
    size: {
      type: String,
      default: '2px'
    },
    activeColor: {
      type: String,
      default: '#5c98f8 '
    },
    inactiveColor: {
      type: String,
      default: '#000'
    }
  },
  setup(props) {
    const { value, size, inactiveColor, activeColor } = toRefs(props)

    const style = computed(() => {
      return {
        height: size.value,
        backgroundColor: inactiveColor.value
      }
    })

    const innerStyle = computed(() => {
      return {
        width: `${value.value}%`,
        backgroundColor: activeColor.value
      }
    })

    return {
      style,
      innerStyle
    }
  }
})
</script>

<style scope>
.ts-progress {
  width: 100%;
}

.ts-progress-inner {
  height: 100%;
  transition: width 0.15s linear;
}
</style>
