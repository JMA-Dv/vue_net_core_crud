import { createPinia } from 'pinia'
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { useApi } from './services/useApi'
import ErrorService from './services/ErrorService'
import Notifications from '@kyvg/vue3-notification'

// createApp(App).use(pinia,router ).mount('#app')

const pinia = createPinia();

const app = createApp(App)
app.config.errorHandler = (error)=> ErrorService.onError(error);

app.use(Notifications)

app.use(pinia)
app.use(router);
app.use(useApi);
app.mount("#app")

