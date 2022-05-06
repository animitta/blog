<template>
  <div class="frame" :style="style">
    <slot></slot>
  </div>
</template>

<script lang="ts">
import { toRefs, computed, defineComponent } from 'vue'

export default defineComponent({
  name: 'Frame',
  props: {
    radius: {
      type: String,
      default: '2px'
    },
    color: {
      type: String,
      required: true
    },
    size: {
      type: String,
      required: true
    }
  },
  setup(props) {
    const { size, radius, color } = toRefs(props)

    const style = computed(() => {
      return {
        padding: size.value,
        borderRadius: radius.value,
        backgroundColor: color.value
      }
    })

    return {
      style
    }
  }
})
</script>

<style scoped>
.frame {
  display: inline-block;
  background-clip: content-box;
  border: 1px solid rgb(216, 216, 216);
  background-color: rgb(255, 255, 255);
}
</style>
