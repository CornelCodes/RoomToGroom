<template>
<div v-if="showModal">
  <CreateCustomerModal/>
</div>
<div v-else>
<div class="container" id="header">
  <div class="customer-list">
    Customer List
  </div>
  <div class="selected-customer">
    Selected Customer
  </div>
</div>
<div class="container" id="content">
  <div class="list">
    <ul class="list-group" id="customers">
      <li class="list-group-item" v-for="customer in customers" :key="customer.name" @click="getSelectedCustomer(customer)">{{customer.name}} {{customer.surname}}
        <button type="button" class="btn btn-outline-secondary">Edit</button>
      </li>
    </ul>
  </div>
  <div class="overview">
    <ul v-if="selectedCustomer != null">
      <li>Name:{{selectedCustomer.name}}</li>
      <li>Surname:{{selectedCustomer.surname}}</li>
      <li>Email:{{selectedCustomer.email}}</li>
      <li>Contact No:{{selectedCustomer.contactNumber}}</li>
      <li>Customer Since:{{selectedCustomer.customerSince}}</li>
      <li>Groom Day:{{selectedCustomer.groomDay}}</li>
      <li>Groom Frequency:{{selectedCustomer.groomFrequency}}</li>
    </ul>
  </div>
</div>
</div>
<div class="container-fluid" id="actions" v-if="showModal === false">
  <button type="button" class="btn btn-outline-primary btn-lg btn-block" @click="toggleShowModal">Create New</button>
</div>
</template>

<script>
import CreateCustomerModal from '../components/CreateCustomerModal'
export default {
  data(){
    return{
      customers: [],
      selectedCustomer: null,
      showModal: false
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
    getSelectedCustomer(customer){
      this.selectedCustomer = customer
    }
  },
  mounted(){
    this.getCustomers();
  },
}
</script>

<style scoped>

.container{
  display: flex;
  padding-top: 10px;
}

.customer-list{
  flex: 1;
  text-align: center;
  border: 1px solid black;
}

.list{
  flex: 1;
}

.selected-customer{
  width: 30%;
  text-align: center;
  border: 1px solid black;
}

.overview{
  width: 30%;
}

#customers li{
  text-align: left;
}

#customers button{
  float: right;
}

.overview ul{
  list-style-type: none;
  text-align: left;
}
</style>