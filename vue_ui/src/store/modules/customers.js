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
        }
    },

    actions: {
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

        createCustomer()
        {
            axios.post("api/customer", this.newCustomer, {
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