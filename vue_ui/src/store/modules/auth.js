import { registerRuntimeCompiler } from "@vue/runtime-core";
import axios from "axios";

export default {
    namespaced: true,
    state: {
        token: localStorage.getItem('token'),
        user: localStorage.getItem('user')
    },

    mutations: {
        LOG_IN(state, token, user)
        {
            console.log("Logging In...");
            localStorage.setItem('token', JSON.stringify(token));
            localStorage.setItem('user', JSON.stringify(user));
            console.log("User: " + localStorage.getItem('user') + "\nToken: " + localStorage.getItem('token') + "\nLogged in")
        },

        LOG_OUT(state)
        {
            console.log("Logging Out...")
            localStorage.removeItem('token')
            localStorage.removeItem('user')
            console.log("Logged out successfuly")
        }
    },

    actions: {
        async logIn({ commit }, credentials)
        {
            let response = await axios.post('api/User/Login', credentials);
            console.log(response.data)
            commit('LOG_IN', response.data.token, response.data)
        },

        async logOut({ commit })
        {
            commit('LOG_OUT')
        },

        async register(_, credentials)
        {
            console.log("Attempting Register...")

            axios.post('api/User/Register', credentials)

            console.log("Register success")
        }
    },
}