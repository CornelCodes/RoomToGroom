<template>
  <LoginModal @login-submit="signIn"/>
</template>

<script>
import { mapActions } from 'vuex'
import LoginModal from '../components/LoginModal'
export default {
  components:{
    LoginModal
  },
  data(){
    return {
      form:{
        email: '',
        password: ''
      }
    }
  },
  methods:{
    ...mapActions({
      logIn: 'auth/logIn'
    }),

    signIn(email, password){
      this.form.email = email;
      this.form.password = password;
      this.logIn(this.form);
      console.log('Submitting')
    },

  }

}
</script>

<style>

</style>