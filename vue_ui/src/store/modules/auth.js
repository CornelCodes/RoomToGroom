
export default {
    namespaced: true,
    state: {
        token: localStorage.getItem('token'),
        user: localStorage.getItem('user')
    },

    mutations: {
        LOG_IN(state, data)
        {
            console.log("Logging In...");
            localStorage.setItem('token', data.token);
            localStorage.setItem('user', JSON.stringify(data.user));
            console.log("User: " + localStorage.getItem('user') + "\nToken: " + localStorage.getItem('token') + "\nLogged in")
        },

        LOG_OUT(state)
        {
            console.log("Logging Out...")
            this.state.token = null
            this.state.user = null
            localStorage.removeItem('token')
            localStorage.removeItem('user')
            console.log("Logged out successfuly")
        }
    },

    actions: {
        async logIn({ commit }, credentials)
        {
            let response = await axios.post('api/User/Login', credentials);
            commit('LOG_IN', response.data)
        },

        async logOut({ commit })
        {
            commit('LOG_OUT')
        },

        async register(_, credentials)
        {
            console.log("Attempting Register...")

            axios.post('api/User/Register', credentials)
                .then(res =>
                {
                    console.log("Register success")
                })
                .catch(err =>
                {
                    console.log(err)
                })

        }
    },
}