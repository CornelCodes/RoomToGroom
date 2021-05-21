<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
  <div class="container-fluid">
    <a class="navbar-brand" href="/" id="logo">
      <img src="../assets/image1.png" alt="logo">
    </a>
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
        <div class="d-flex" v-if="isHome">
          <button class="btn btn-outline-primary" type="submit" @click="signOut">Sign Out</button>
        </div>
      <form class="d-flex" v-else>
        <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
        <button class="btn btn-outline-success" type="submit">Search</button>
      </form>
    </div>
  </div>
</nav>
</template>

<script>
import { mapActions } from 'vuex'
export default {
  props:{
    isHome: Boolean,
  },
  data(){
    return{
      user: { },
    }
  },
  methods:{
    ...mapActions({
      logOut: 'auth/logOut'
  }),

    async signOut(){
      await this.logOut();
      this.$router.push('/Login')
    },

  },
  mounted(){
    console.log("Mounted")
    this.user = JSON.parse(localStorage.getItem('user'))
    console.log(this.user)
  }
}
</script>

<style scoped>
.login{
  position: fixed;
  left: 50%;
  top: 50%;
}

#logo{
  display: flex;
  position: relative;
  left: 48%;
  width: 50px;
  height: 50px;
  border: 1px solid black;
  border-radius: 50%;
}
</style>