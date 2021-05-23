import axios from "axios";

export default {
    namespaced: true,
    state: {
        userPets: [],
    },

    mutations: {
        SET_PETS(state, pets)
        {
            state.userPets = pets;
            console.log(pets)
        }
    },

    actions: {
        async getAllPets({ commit })
        {
            await axios.get('api/Pet/GetAll', {
                headers: {
                    "Authorization": `Bearer ${localStorage.getItem('token')}`
                }
            })
                .then(res =>
                {
                    commit('SET_PETS', res.data)
                    console.log('Success getting pets')
                })
                .catch(err =>
                {
                    console.log(err)
                })
        },
    }
}