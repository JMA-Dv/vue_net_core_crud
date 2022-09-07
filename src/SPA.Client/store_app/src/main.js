import { createPinia } from 'pinia'
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import proxies from './proxies/index'
import { useApi } from './services/useApi'
import ErrorService from './services/ErrorService'
// createApp(App).use(pinia,router ).mount('#app')

const pinia = createPinia();

const app = createApp(App)
app.config.errorHandler = (error)=> ErrorService.onError(error);
app.use(pinia)
app.use(router);
app.use(proxies);
app.use(useApi);
app.mount("#app")

