import axios from "axios"

export default {
    namespaced: true,
    state: {
        userCustomers: [],
        events: [],
    },

    mutations: {
        SET_CUSTOMERS(state, customers)
        {
            state.userCustomers = customers
            console.log(customers)
        },

        ADD_EVENTS(state, events)
        {
            events.forEach(event =>
            {
                state.events.push(event)
                console.log("Event: " + event + " added")
            });
        }
    },

    actions: {

        //Get all customers
        async getAllCustomers({ commit })
        {

            await axios.get('api/Customer/GetAll', {
                headers: {
                    "Authorization": `Bearer ${localStorage.getItem('token')}`
                }
            })
                .then(res =>
                {
                    console.log('Success getting customers')
                    commit('SET_CUSTOMERS', res.data)
                })
                .catch(err =>
                {
                    console.log(err)
                })
        },

        //Update customer
        async update({ dispatch }, customer)
        {
            await axios.put('api/Customer/Update', customer)
                .then(res =>
                {
                    dispatch('getAllCustomers')
                })
                .catch(err =>
                {
                    console.log(err)
                })
        },

        //Get all the groom days and frequencies
        async getEvents({ commit })
        {
            console.log('Getting events')
        },

        //Delete customer 
        async delete({ dispatch }, customerId)
        {
            console.log(customerId)
            await axios({
                method: 'DELETE',
                url: 'api/Customer/Delete',
                params: {
                    customerId,
                },
                headers: {
                    Authorization: `Bearer ${localStorage.getItem("token")}`,
                }
            })
                .then(res =>
                {
                    dispatch('getAllCustomers')
                })
                .catch(err =>
                {
                    console.log(err)
                })
        },

        //Create new customer
        async create({ dispatch }, customer)
        {
            await axios.post("api/customer/Post", customer, {
                headers: {
                    Authorization: `Bearer ${localStorage.getItem("token")}`,
                },
            })
                .then((res) =>
                {
                    console.log("Success creating customer");
                    dispatch('getAllCustomers')
                    //Refresh list data
                })
                .catch((err) =>
                {
                    console.log(err);
                });

        }
    }
}