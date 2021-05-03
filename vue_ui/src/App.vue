<template>
<div>
<SignIn/>
</div>
</template>

<script>
import SignIn from "./components/SignIn"
import NavBar from "./components/NavBar"
import Dashboard from "./components/Dashboard"
export default {
  name: 'App',
  components: {
    NavBar,
    SignIn,
    Dashboard,
  },
  data(){
    return{
      userLoggedIn: false,
      isRegistering: false,
      users: [],
    }
  },
  created(){
    
  },
  methods:{
    
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
