<template>
  <div class="header">
    <div class="customer-display">
      <div class="selected-customer">

      </div>
    </div>
      <div class="customer-list">
        <ul class="list-group" >
          <li class="list-group-item" v-for="customer in customers" :key="customer.name">
            {{customer.name}}
          </li>
        </ul>
          <button type="button" class="btn btn-primary">Edit</button>
      </div>
  </div>
  <div class="add-customer">
      <div v-if="showModal">
        <CreateCustomerModal/>
      </div>
    <div v-else>
      <button type="button" class="btn btn-secondary" @click="toggleShowModal">Add Customer</button>
    </div>
  </div>
</template>

<script>
import CreateCustomerModal from '../components/CreateCustomerModal'
export default {
  data(){
    return{
      customers: [],
      showModal: false,
    }
  },
  components:{
    CreateCustomerModal
  },
  methods:{
    getCustomers(){
      this.customers = axios.get('api/customer')
      .then(res => {
        if(res != null){
          this.customers = res.data;
        }
      })
    },
    toggleShowModal(){
      this.showModal = !this.showModal;
    },
  },
  mounted(){
    this.getCustomers();
  }

}
</script>

<style>

.modal{
  width: 90%;
  border: 1px solid black;
}

.add-customer{
  position: sticky;
  bottom: 0;
  width: 100%;
}

.add-customer button{
  color: white;
}

.customer-display{
  border: 1px solid black;
  display: block;
  margin: auto;
  width: 90%;
}
.list-group-item button{
  margin: 0;
  padding: 0;
  right: 10%;
  float: right;
}

.add-customer button{
  margin: 10px;
  padding: 10px;
  border: 10px;
}
</style>