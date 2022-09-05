import { createPinia } from 'pinia'
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import proxies from './proxies/index'
import { useApi } from './services/useApi'
// createApp(App).use(pinia,router ).mount('#app')

const pinia = createPinia();

const app = createApp(App)
app.use(pinia)
app.use(router);
app.use(proxies);
app.use(useApi);
app.mount("#app")

