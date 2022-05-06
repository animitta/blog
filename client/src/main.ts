import App from "./App.vue";
import { createApp } from "vue";
import router from './router'
import 'vite-plugin-svg-icons/register';
import Icon from './components/Icon'

createApp(App)
    .use(router)
    .component('Icon', Icon)
    .mount("#app");
