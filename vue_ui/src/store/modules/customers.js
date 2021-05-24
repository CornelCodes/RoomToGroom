import axios from "axios"

export default {
    namespaced: true,
    state: {
        userCustomers: []
    },

    mutations: {
        SET_CUSTOMERS(state, customers)
        {
            state.userCustomers = customers
            console.log(customers)
        },

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
        async createCustomer()
        {
            await axios.post("api/customer", this.newCustomer, {
                headers: {
                    Authorization: `Bearer ${localStorage.getItem("token")}`,
                },
            })
                .then((res) =>
                {
                    console.log("Success creating customer");
                    this.showCreateCustomer = false;
                    this.getCustomers();
                    //Refresh list data
                })
                .catch((err) =>
                {
                    console.log(err);
                });

        }
    }
}