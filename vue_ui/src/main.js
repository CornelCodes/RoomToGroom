import { createApp } from 'vue'

//Axios
import VueAxios from 'vue-axios'
import axios from './axios/axios'

//Views
import App from './App.vue'

//Bootstrap
import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'

//Router
import router from './router/router'

//Store
import store from './store/store'

//App
const app = createApp(App);

app.use(VueAxios, axios);
app.use(router)
app.use(store)
app.mount('#app');