export default {
    namespaced: true,
    state: {
        token: null,
        user: null,
    },

    mutations: {

    },

    actions: {
        async logIn({ dispatch }, credentials)
        {
            let response = await axios.post('api/User/Login', credentials)
            dispatch('attempt', response.data.token)
        },

        async attempt(_, token)
        {
            console.log(token)
        }
    },
}