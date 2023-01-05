import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { useApi } from './services/useApi'
import ErrorService from './services/ErrorService'
import Notifications from '@kyvg/vue3-notification'
import store from './store/store'
const app = createApp(App)
app.config.errorHandler = (error)=> ErrorService.onError(error);

app.use(store)
app.use(router);
app.use(Notifications)

app.use(useApi);
app.mount("#app")

