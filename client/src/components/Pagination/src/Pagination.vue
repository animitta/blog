<template>
  <nav class="section pagination">
    <a class="extend prev" rel="prev" href="/">
      <Icon type="angle-left" aria-label="上一页" />
    </a>

    <a class="page-number" href="/">1</a>

    <span class="page-number current">2</span>
    
    <a class="page-number" href="/page/3/">3</a>
    
    <span class="space">…</span>
    
    <a class="page-number" href="/page/5/">5</a>

    <a class="extend next" rel="next" href="/page/3/">
      <Icon type="angle-right" aria-label="下一页" />
    </a>
  </nav>
</template>    

<script lang="ts">
import Icon from '@/components/Icon'

export default {
  name: 'Pagination',
  components: {
    Icon
  }
}
</script>

<style scoped>
.pagination {
  padding: 10px 0;
  text-align: center;
  background-color: #fff;
}

.pagination .prev:hover, .pagination .next:hover, .pagination .page-number:hover {
    border-top-color: #222;
}
.pagination .prev, .pagination .next, .pagination .page-number {
    margin-bottom: initial;
    top: initial;
}
.pagination .prev, .pagination .next, .pagination .page-number {
    border-bottom: 0;
    border-top: 1px solid #eee;
    transition-property: border-color;
    transition-duration: 0.2s;
    transition-timing-function: ease-in-out;
    transition-delay: 0s;
}

.page-number-basic, .pagination .prev, .pagination .next, .pagination .page-number, .pagination .space {
    display: inline-block;
    position: relative;
    top: -1px;
    margin: 0 10px;
    padding: 0 11px;
}
a:hover, span.exturl:hover {
    color: #222;
    border-bottom-color: #222;
}
a:active, a:hover {
    outline: 0;
}
a, span.exturl {
    overflow-wrap: break-word;
    word-wrap: break-word;
    background-color: transparent;
    color: #555;
    text-decoration: none;
    outline: none;
    border-bottom: 1px solid #999;
    cursor: pointer;
}
</style>
