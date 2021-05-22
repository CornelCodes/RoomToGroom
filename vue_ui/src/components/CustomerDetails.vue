<template>
  <div class="container-fluid">
      <div id="modal">
        <table class="table table-striped">
            <thead>
                <th>Edit Customer</th>
                <th>Pet List</th>
            </thead>
            <tbody>
                <td>
                    <label for=""></label>
                    <input type="text" class="form-control" :placeholder="customer.name">
                    <input type="text" class="form-control" :placeholder="customer.surname">
                    <input type="text" class="form-control" :placeholder="customer.email">
                    <input type="text" class="form-control" :placeholder="customer.contactNumber">
                </td>
                <td>
                    <ul class="list-group" v-for="pet in pets" :key="pet.petId">
                        <li class="list-group-item">{{pet.name}}</li>

                    </ul>
                </td>
            </tbody>
        </table>
      </div>
  </div>
</template>

<script>
export default {
    props:{
        customer: Object,
    },

    data(){
        return{
            pets: [],
        }
    },

    methods:{
        getPets(){
            axios.get('api/Pet/GetByCustomerId', {
                'customerId': this.customer.customerId,
                headers:{
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('token')}`
                }
            })
            .then(res =>{
                this.pets = res.data
                console.log("Success")
            })
            .catch(err => {
                console.log(err)
            })
        }
    },

    mounted(){
        console.log('updated')
        this.getPets()
    }

}
</script>

<style scoped>
*{
    margin: 0;
    padding: 0;
}

#modal{
    position: fixed;
    width: 50%;
    height: 90%;
    background: white;
    border: 1px solid black;
}
</style>