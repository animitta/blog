import { withInstall } from '../../utils';
import article from './src/Article.vue';
import articleSummary from './src/ArticleSummary.vue';

export const Article = withInstall(article);
export const ArticleSummary = withInstall(articleSummary);
