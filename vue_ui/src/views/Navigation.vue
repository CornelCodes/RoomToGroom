<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
  <div class="container-fluid">
    <a class="navbar-brand" href="/">Room To Groom</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            <li class="nav-item">
                <a href="/" class="nav-link">Home</a>
            </li>
            <li class="nav-item">
                <a href="Pets" class="nav-link">Pets</a>
            </li>
            <li class="nav-item">
                <a href="Customers" class="nav-link">Customers</a>
            </li>
        </ul>
      <form class="d-flex">
        <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
        <button class="btn btn-outline-success" type="submit">Search</button>

        <div class="container">
          <div v-if="signedIn">
            {{user.name}}
            <button type="button" class="btn btn-primary" @click="signOut">Sign Out</button>
          </div>
          <div v-else>
            <button type="button" class="btn btn-primary" @click="toggleShowModal">Sign In</button>
          </div>
        </div>
      </form>
    </div>
  </div>
</nav>
<div v-if="showModal" class="login">
<Login @login-submit="signIn"/>
</div>
</template>

<script>
import Login from '../components/LoginModal'
export default {
  data(){
    return{
      user: null,
      showModal: false
    }
  },
  props:{
    signedIn: Boolean,
  },
  components:{
    Login
  },
  methods:{
    toggleShowModal(){
      this.showModal = !this.showModal;
    },
    signIn(email, password){
      console.log("Attempting sign in...")
      axios.get('api/Groomer', {
        'Email': email,
        'Password': password
      })
      .then(res => {
        this.$emit('signed-in', res.data);
        this.user = res.data;
      })
      .catch(err => {
        console.log("Error signing in : " + err)
      })
    },
    signOut(){

    }
  }
}
</script>

<style scoped>
.login{
  position: fixed;
  left: 50%;
  top: 50%;
}
</style>