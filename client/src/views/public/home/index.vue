<template>
  <Progress :value="percent" class="loading-progress" />
  <Profile />
  <Search v-if="showSearch" />
  <GitHubCorner />
  <Toolbar />
  <div class="main">
    <ArticleSummary />
    <Pagination />
    <Footer />
  </div>
</template>

<script lang="ts">
import Search from '@/components/Search'
import Toolbar from '@/components/Toolbar'
import Profile from '@/components/Profile'
import Progress from '@/components/Progress'
import { GitHubCorner } from '@/components/GitHub'
import { Pagination } from '@/components/Pagination'
import { ArticleSummary } from '@/components/Article'
import { Footer } from '@/components/Footer'
import { onMounted, ref } from 'vue'

export default {
  name: 'Home',
  components: {
    Progress,
    Profile,
    GitHubCorner,
    ArticleSummary,
    Pagination,
    Footer,
    Toolbar,
    Search
  },
  setup() {
    const percent = ref(0)
    const showSearch = ref(false)

    onMounted(() => {
      let pressTimer: any
      const body = document.body

      const calcPercent = () => {
        const scrollY = window.scrollY
        const innerHeight = window.innerHeight
        const contentHeight = body.clientHeight
        const value = Math.ceil(((scrollY + innerHeight) / contentHeight) * 100)
        percent.value = value
      }

      calcPercent()
      window.addEventListener('scroll', calcPercent)
      window.addEventListener('resize', calcPercent)

      body.addEventListener('mouseup', (e: MouseEvent) => {
        if (e.target) {
          const element = e.target as Element
          if (element.id === 'app') {
            body.classList.remove('active')
            clearTimeout(pressTimer)
          }
        }
      })
      body.addEventListener('mousedown', (e: MouseEvent) => {
        if (e.target) {
          const element = e.target as Element
          if (element.id === 'app') {
            pressTimer = setTimeout(() => {
              body.classList.add('active')
            }, 300)
          }
        }
      })
    })

    return {
      percent,
      showSearch
    }
  }
}
</script>

<style scoped>
.main {
  margin: auto;
  width: calc(100vw - 550px);
  padding-top: var(--theme-gutter-size);
  max-width: var(--max-width-size);
}

.loading-progress {
  z-index: 11;
  position: fixed;
  height: var(--progress-width-size) !important;
}

@media screen and (max-width: 1200px) {
  .main {
    width: 100vw;
  }
}
</style>

<style>
html {
  background-size: cover;
  background-repeat: no-repeat;
  background-attachment: fixed;
  background-position: center center;
  backdrop-filter: blur(50px) saturate(50%);
  background-image: url('/image/background.jpg');
}

body::after {
  top: 0;
  left: 0;
  content: '';
  z-index: -1;
  width: 100vw;
  height: 100vh;
  position: fixed;
  backdrop-filter: blur(20px) saturate(80%);
  background-color: rgba(200, 200, 200, 0.7);
}

body.active::after {
  transition: all 0.2s ease-out;
  backdrop-filter: blur(0px) saturate(100%);
  background-color: rgba(120, 120, 120, 0.05);
}
</style>
