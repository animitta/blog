<template>
    <div class="section about">
        <header class="about-header">
            <h1 itemprop="about me">关于博主</h1>
        </header>

        <div class="about-body">
            <h2>兴趣方向</h2>
            <p>.NET全栈, 软件架构设计, 复杂性科学, 嵌入式, 物联网, 乒乓球, 长跑...(太广泛了,哈哈)</p>

            <h2>建站初衷</h2>
            <p>记录自己的学习历程，分享一些好玩的、经典的论文。构建一个能够和他人交流的平台，不断精进自己的技术、研究水平。</p>

            <h2>联系方式</h2>
            <p>欢迎大家通过以下联系方式和我交流问题，互相学习。</p>
            <ul>
                <li>thinkershare@163.com</li>
                <li>thinkershare@outlook.com</li>
            </ul>

            <h2>文章转载</h2>
            <p>如需转载文章，请通过以上联系方式联系我。</p>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
    name: 'About',
})
</script>

<style scoped>
.about {
    padding: 10px 30px 30px;
    background-color: #fff;
    font-family: 'Lato', "PingFang SC", "Microsoft YaHei", sans-serif;
}

.about h1{
    font-size: 1.6em;
}

.about h2{
    font-size: 1.3em;
    border-bottom: 1px solid #eee;
}

.about h1,h2,h3{
    line-break: 1.5;
    padding-top: 10px;
    margin: 20px 0 15px;
}

.about-header{
    text-align: center;
}

.about-body{
    text-align: justify;
}

.about-body ul li{
    list-style: circle;
}
</style>
