import { createApp } from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import App from './App.vue'
import Home from './views/Home.vue'
import Customers from './views/Customers.vue'
import Pets from './views/Pets.vue'
import Login from './views/Login.vue'
import Register from './views/Register.vue'

//Bootstrap
import Bootstrap from 'bootstrap'
import { createRouter, createWebHistory } from 'vue-router'

//Axios
window.axios = axios
axios.defaults.baseURL = 'https://localhost:5001/'

//Router
const routes = [
    {
        path: '/',
        name: 'Login',
        component: Login
    },
    {
        path: '/Register',
        name: 'Register',
        component: Register
    },
    {
        path: '/Home',
        name: 'Home',
        component: Home
    },
    {
        path: '/Pets',
        name: 'Pets',
        component: Pets
    },
    {
        path: '/Customers',
        name: 'Customers',
        component: Customers
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes: routes,
});

const app = createApp(App);
app.use(VueAxios, axios);
app.use(router)
app.mount('#app');