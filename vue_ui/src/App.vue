<template>
<div>
<NavBar @userUpdated="updateUser"/>
<div v-if="user != null">
  <Dashboard :user="user"/>
</div>
<CustomerList/>
</div>
</template>

<script>
//Import components
import SignIn from "./components/SignIn"
import NavBar from "./components/NavBar"
import Dashboard from "./components/Dashboard"
import PetList from './components/PetList'
import CustomerList from './components/CustomerList.vue'

export default {
  name: 'App',
  components: {
    NavBar,
    SignIn,
    Dashboard,
    CustomerList,
    PetList
  },
  data(){
    return{
      userLoggedIn: false,
      isRegistering: false,
      user: null,
    }
  },
  methods:{
    updateUser(value){
      this.user = value;
    }
  },
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
