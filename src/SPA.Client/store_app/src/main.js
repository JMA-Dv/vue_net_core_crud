import { createPinia } from 'pinia'
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

const pinia = createPinia();
// createApp(App).use(pinia,router ).mount('#app')

const app = createApp(App)
app.use(router);
app.use(pinia)
app.mount("#app")

