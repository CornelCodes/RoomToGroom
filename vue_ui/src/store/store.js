//Vuex
import { createStore } from 'vuex'
import createPersistedState from 'vuex-persistedstate'
import auth from './modules/auth'
import pets from './modules/pets'
import customers from './modules/customers'

//Store
const store = createStore({
    plugins: [createPersistedState()],
    state:
    {

    },

    mutations: {
    },

    actions: {
    },

    modules: {
        auth,
        pets,
        customers,
    }
})

export default store;