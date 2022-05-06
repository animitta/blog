<template>
  <footer class="section footer text-center text-secondary">
    <div class="counter">
      <span class="site-uv">
        <Icon type="sum" />总博文: <span class="busuanzi-value" id="busuanzi_value_site_uv">{{ articleCount }}</span> 篇
      </span>

      <span class="footer-divider">|</span>

      <span class="site-uv">
        <Icon type="draw" />总字数: <span class="busuanzi-value" id="busuanzi_value_site_pv">{{ characterCount }} k</span> 字
      </span>

      <span class="footer-divider">|</span>

      <span class="site-uv">
        <Icon type="user" /> 访问用户: <span class="busuanzi-value" id="busuanzi_value_site_uv">{{ visitorCount }}</span> 人
      </span>

      <span class="footer-divider">|</span>

      <span class="site-uv">
        <Icon type="eye" /> 访问次数: <span class="busuanzi-value" id="busuanzi_value_site_pv">{{ visitTimes }}</span> 次
      </span>
    </div>

    <div class="copyright">
      <span class="powered-by">
        <a :href="dotNetUrl" class="text-link" rel="noopener noreferrer" target="_blank">{{ dotNetVersion }}</a>
        强力驱动
      </span>

      <span class="ipc">
        <a class="text-link" :href="icpUrl" target="_blank">{{ icp }}</a>
        ©<span itemprop="copyright-year">{{ year }}</span>
      </span>

      <span class="author" itemprop="copyright-author"> thinkershare</span>
    </div>
  </footer>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Icon from '@/components/Icon'

export default defineComponent({
  name: 'Footer',
  components: {
    Icon
  },
  setup() {
    const year = new Date().getFullYear()

    return {
      year,
      articleCount: 123,
      characterCount: 123.5,
      visitorCount: 123,
      visitTimes: 1234,
      dotNetVersion: '.NET6',
      dotNetUrl: 'https://dotnet.microsoft.com/zh-cn/',
      icp: '渝ICP备15003818号',
      icpUrl: 'https://beian.miit.gov.cn/'
    }
  }
})
</script>

<style scoped>
.footer {
  padding: 1em 0;
  border-radius: 4px;
  background-color: #fff;
}

.footer-divider {
  padding-right: 0.5em;
}
</style>
