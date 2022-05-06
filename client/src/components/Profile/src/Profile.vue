<template>
  <div class="expand-menu" @click="handleExpand" :class="stateClass">
    <svg viewBox="0 0 32 32" width="100%" height="100%">
      <path d="M30 18h-28c-1.1 0-2-0.9-2-2s0.9-2 2-2h28c1.1 0 2 0.9 2 2s-0.9 2-2 2zM30 6.25h-28c-1.1 0-2-0.9-2-2s0.9-2 2-2h28c1.1 0 2 0.9 2 2s-0.9 2-2 2zM2 25.75h28c1.1 0 2 0.9 2 2s-0.9 2-2 2h-28c-1.1 0-2-0.9-2-2s0.9-2 2-2z" />
    </svg>
    <span>&nbsp; profile</span>
  </div>

  <div class="profile" :class="stateClass" @mousewheel.stop.prevent="handleClose">
    <Board />
    <Navbar />
  </div>
</template>    

<script lang="ts">
import { ref } from 'vue'
import Board from './Board.vue'
import Navbar from './Navbar.vue'
import Icon from '@/components/Icon/'

export default {
  name: 'Profile',
  props: {
    defaultExpand: {
      type: Boolean,
      default: true
    }
  },
  components: {
    Icon,
    Board,
    Navbar
  },
  setup(props: any) {
    const openState = 'opened'
    const closeState = 'closed'

    const defaultState = props.defaultExpand ? openState : closeState
    const stateClass = ref(defaultState)

    const handleClose = () => {
      stateClass.value = closeState
    }

    const handleExpand = () => {
      stateClass.value = openState
    }

    return {
      stateClass,
      handleClose,
      handleExpand
    }
  }
}
</script>

<style lang="less" scoped>
.profile {
  top: 0;
  left: 0;
  z-index: 9;
  height: 100vh;
  position: fixed;
  overflow: hidden;
  animation-duration: 1s;
  animation-fill-mode: both;
  padding-top: var(--theme-gutter-size);
  background-color: var(--theme-bg-color);
  backdrop-filter: blur(30px) saturate(125%);
}

.profile.opened {
  transition: left 0.25s ease-out;
  animation-name: bounce-in-left;
}

.profile.closed {
  transition: left 0.15s ease-in;
  animation-name: bounce-out-left;
}

.expand-menu {
  top: 20px;
  left: 20px;
  z-index: 9;
  padding: 10px;
  display: flex;
  cursor: pointer;
  color: #000;
  position: fixed;
  font-size: 12px;
  user-select: none;
  border-radius: 3px;
  align-items: center;
  text-transform: uppercase;
  border: 1px solid #000;
  transition: opacity 0.25s ease-in-out;
}

.expand-menu .opened {
  opacity: 0;
}

.expand-menu .closed {
  opacity: 1;
}

.expand-menu.closed:hover {
  opacity: 0.5;
}

.expand-menu.opened {
  opacity: 0;
}

.expand-menu svg {
  fill: currentColor;
  display: inline-block;
  stroke-width: 0;
  stroke: currentColor;
  width: 14px;
  height: 14px;
}
</style>
