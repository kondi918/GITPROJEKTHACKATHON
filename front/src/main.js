import { createApp } from 'vue'
import App from './App.vue'
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap"
import router from './router.js';


createApp(App)
.use(router) // Użyj routera
.mount('#app');
