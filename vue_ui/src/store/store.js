//Vuex
import { createStore } from 'vuex'
import createPersistedState from 'vuex-persistedstate'
import auth from './modules/auth'

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

export default store;