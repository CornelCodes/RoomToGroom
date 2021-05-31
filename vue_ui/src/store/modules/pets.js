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

        async create({ dispatch }, newPet)
        {
            console.log("Attempting to create..")
            await axios.post('api/Pet', newPet, {
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": `Bearer ${localStorage.getItem('token')}`
                }
            })
                .then(res =>
                {
                    dispatch('getAllPets')
                    console.log("Created pet")
                })
                .catch(err =>
                {
                    console.log(err)
                })
        },

        async update({ dispatch }, updatedPet)
        {
            await axios.put('api/Pet/Update', updatedPet, {
                headers: {
                    "Authorization": `Bearer ${localStorage.getItem('token')}`
                }
            })
                .then(res =>
                {
                    dispatch("getAllPets");
                    console.log('Updated ' + updatedPet.name)
                })
                .catch(err =>
                {
                    console.log(err)
                })
        },

        async remove({ dispatch }, petId)
        {
            await axios.delete('api/Pet/' + petId, {
                headers: {
                    "Authorization": `Bearer ${localStorage.getItem('token')}`
                }
            })
        }
    }
}