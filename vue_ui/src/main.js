import { createApp } from 'vue'

//Axios
import axios from 'axios'
import VueAxios from 'vue-axios'
window.axios = axios
axios.defaults.baseURL = 'https://localhost:5001/'

//Vuex
import { createStore } from 'vuex'
import createPersistedState from 'vuex-persistedstate'
import auth from './store/modules/auth'

//Views
import App from './App.vue'
import Home from './views/Home.vue'
import Customers from './views/Customers.vue'
import Pets from './views/Pets.vue'
import Login from './views/Login.vue'
import Register from './views/Register.vue'

//Bootstrap
import Bootstrap from 'bootstrap'
import { createRouter, createWebHistory } from 'vue-router'


//Store
const store = createStore({
    plugins: [createPersistedState()],
    state()
    {
        return {
        }
    },
    mutations: {
    },
    modules: {
        auth
    }
})

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
app.use(store)
app.mount('#app');