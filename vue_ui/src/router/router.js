import { createWebHistory, createRouter } from "vue-router";

//Views
import Home from '../views/Home.vue'
import Customers from '../views/Customers.vue'
import Pets from '../views/Pets.vue'
import Login from '../views/Login.vue'
import Register from '../views/Register.vue'

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
    routes
})

export default router;
