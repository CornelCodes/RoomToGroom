import { createApp } from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import App from './App.vue'

window.axios = axios
axios.defaults.baseURL = 'https://localhost:5001/'

createApp(App).use(VueAxios, axios).mount('#app')