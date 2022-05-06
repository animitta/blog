<template>
  <article class="section article-summary" v-for="i in 40" :key="i">
    <header class="article-header">
      <h1 class="article-title" itemprop="article title">
        <a href="/article/test-info" class="article-title-link">好用又令人头大的二叉树</a>
      </h1>

      <div class="article-meta">
        <span class="article-time">
          <Icon type="calendar" />
          <span class="article-meta-item-text">发表于</span>
          <time title="创建时间：2020-01-03 11:39:20 / 修改时间：11:42:14" itemprop="dateCreated datePublished" datetime="2020-01-03T11:39:20+08:00">2020-01-03</time>
        </span>

        <span class="article-divider">|</span>

        <span class="article-time">
          <Icon type="calendar-check" />
          <span class="article-meta-item-text">发表于</span>
          <time title="创建时间：2020-01-03 11:39:20 / 修改时间：11:42:14" itemprop="dateCreated datePublished" datetime="2020-01-03T11:39:20+08:00">2020-01-03</time>
        </span>

        <span class="article-divider">|</span>

        <span class="article-category">
          <Icon type="folder" />
          <span class="article-meta-item-text">分组于 </span>

          <span itemprop="about">
            <a href="/categories/深度学习/">
              <span itemprop="name">深度学习</span>
            </a> </span
          >，

          <span itemprop="about">
            <a href="/categories/深度学习/实例分割/">
              <span itemprop="name">实例分割</span>
            </a> </span
          >，

          <span itemprop="about">
            <a href="/categories/深度学习/实例分割/实时实例分割/">
              <span itemprop="name">实时实例分割</span>
            </a>
          </span>
        </span>
      </div>
    </header>

    <main class="article-body" itemprop="articleBody">
      <p>这篇文章的目标是解决实例分割的实时性问题。通过在现有one-stage目标检测模型的基础上添加mask分支来解决这一问题。与Mask R-CNN等明显使 ...</p>
      '

      <div class="article-button text-center">
        <a class="btn" href="/shen-du-xue-xi/shi-li-fen-ge/yolact-and-yolact/#more" rel="contents"> 阅读全文 » </a>
      </div>
    </main>

    <footer class="article-footer">
      <div class="article-eof"></div>
    </footer>
  </article>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'ArticleSummary',
  setup() {
    return {}
  }
})
</script>

<style scoped>
.article-summary {
  font-size: 18px;
  padding: 10px 30px 30px;
  background-color: var(--theme-bg-color);
  backdrop-filter: blur(50px) saturate(50%);
}

.article-header {
  font-weight: 400;
  text-align: center;
  word-wrap: break-word;
}

.articles-expand .article-title-link {
  line-height: inherit;
}
.articles-expand .article-title-link {
  display: inline-block;
  position: relative;
  color: #555;
  border-bottom: none;
  line-height: 1.2;
  vertical-align: top;
}

a {
  overflow-wrap: break-word;
  word-wrap: break-word;
  background-color: transparent;
  color: #555;
  text-decoration: none;
  outline: none;
  border-bottom: 1px solid #999;
  cursor: pointer;
}

.articles-title-link {
  position: relative;
}

.articles-title-link:hover:before {
  content: '';
  position: absolute;
  left: 0;
  bottom: 0;
  height: 2px;
  width: 100%;
  visibility: hidden;
  transform: scaleX(0);
  background-color: #000;
  transition-delay: 0s;
  transition-duration: 0.2s;
  transition-timing-function: ease-in-out;
}

.articles-expand .article-title {
  font-size: 1.7em;
}

.articles-expand .article-title {
  overflow-wrap: break-word;
  word-wrap: break-word;
  text-align: center;
  font-weight: 400;
}

time {
  cursor: help;
}

.article-meta {
  font-size: 12px;
  color: #999;
  text-align: center;
  margin: 3px 0 60px 0;
  font-family: 'Lato', 'PingFang SC', 'Microsoft YaHei', sans-serif;
}

.article-divider {
  margin: 0 0.5em;
}

.article-title-link {
  line-height: 1.2;
  font-weight: 400;
  color: #555;
  vertical-align: top;
  text-decoration: none;
}
</style>
