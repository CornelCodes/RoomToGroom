import { createWebHistory, createRouter } from "vue-router";

//Views
import Home from '../views/Home.vue'
import Customers from '../views/Customers.vue'
import Pets from '../views/Pets.vue'
import Login from '../views/Login.vue'
import Register from '../views/Register.vue'

const routes = [
    {
        path: '/Login',
        name: 'Login',
        component: Login,
        meta: {
            requiresAuth: false,
        }
    },
    {
        path: '/Register',
        name: 'Register',
        component: Register
    },
    {
        path: '/',
        name: 'Home',
        component: Home,
        meta: {
            requiresAuth: true,
        }
    },
    {
        path: '/Pets',
        name: 'Pets',
        component: Pets,
        meta: {
            requiresAuth: true,
        }
    },
    {
        path: '/Customers',
        name: 'Customers',
        component: Customers,
        meta: {
            requiresAuth: true,
        }
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

//Block routes to views that require auth if user has no token
router.beforeEach((to, from, next) =>
{
    if (to.matched.some((record) => record.meta.requiresAuth))
    {
        console.log(localStorage.getItem('token'))
        if (localStorage.getItem('token') != null)
        {
            next()
        }
        else
        {
            next('/Login')
        }
    }
    else
    {
        next()
    }
})

export default router;
