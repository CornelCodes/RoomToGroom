<template>
  <div>
    <RegisterModal @submit-register='register'/>
  </div>
</template>

<script>
import RegisterModal from '../components/RegisterModal'
export default {
components:{
  RegisterModal,
},
data(){
  return{

  }
},
methods:{
  register(name, email, password){
    console.log("Attempting register...")
    var user = {
      'name': name,
      'email': email,
      'password': password,
    }

    var headers = {
      "Content-Type": "application/json"
      }

    axios.post('api/User/Register', user, headers)
    .then(res => {
      console.log('Register success\n' + res.data)
    })
    .catch(err => {
      console.log(err)
    })
  }
}
}
</script>

<style>

</style>