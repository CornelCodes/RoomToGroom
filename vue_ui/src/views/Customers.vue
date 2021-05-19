<template>
<div class="nav-bar">
  <NavBar/>
</div>
<div v-if="showModal">
  <CreateCustomerModal/>
</div>
<div v-else>

</div>
<div class="container-fluid" id="actions" v-if="showModal === false">
  <button type="button" class="btn btn-outline-primary btn-lg btn-block" @click="toggleShowModal">Create New</button>
</div>
</template>

<script>
import NavBar from '../components/NavBar'
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
  components:{
    NavBar
  }
}
</script>

<style scoped>
*{
}

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

.navbar{
  position: fixed;
  top: 0;
  width: 100%;
}
</style>