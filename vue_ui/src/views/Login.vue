<template>
  <LoginModal @login-submit="signIn"/>
</template>

<script>
import LoginModal from '../components/LoginModal'
export default {
  components:{
    LoginModal
  },
  data(){
    return {
      signedIn: false,
      user: null,
    }
  },
  methods:{
    signIn(email, password){
      //Sign in logic here
      var headers = {
      "Content-Type": "application/json"
      }

      var user = {
        'email': email,
        'password': password,
      }

      console.log("Attempting sign in...")
      axios.post("api/User/Login", user, headers)
      .then(res => {
        console.log("Success:\n" + res.data)
        this.user = res.data;
        this.$store.commit('setUser', this.user)
        this.$router.push({ path: 'Home'});
      })
      .catch(err => {
        console.log(err)
      })
      //Redirect to home
    }
  }

}
</script>

<style>

</style>