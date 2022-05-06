<template>
  <svg :class="svgClass" aria-hidden="true">
    <use :xlink:href="iconName" :fill="color" />
  </svg>
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue'

export default defineComponent({
  props: {
    type: {
      type: String,
      required: true
    },
    className: {
      type: String,
      default: ''
    },
    color: {
      type: String,
      default: '#889aa4'
    }
  },
  setup(props) {
    return {
      iconName: computed(() => `#icon-${props.type}`),
      svgClass: computed(() => {
        return props.className ? `svg-icon ${props.className}` : 'svg-icon'
      })
    }
  }
})
</script>

<style scope>
.svg-icon {
  width: 1em;
  height: 1em;
  fill: currentColor;
  margin-top: -0.25em;
  margin-right: 0.5em;
  vertical-align: middle;
}
</style>
