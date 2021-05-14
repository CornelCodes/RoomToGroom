<template>
<div class="top">
<NavBar :signedIn="signedIn" @signed-in="setUser"/>
</div>
<div class="currentView">
  <router-view></router-view>
</div>
<div class="footer">
  <!-- <Footer/> -->
</div>
</template>

<script>
//Import components
import NavBar from './views/Navigation.vue'
import Footer from './components/Footer'

export default {
  name: 'App',
  components: {
    NavBar,
    Footer
  },
  data(){
    return{
      user: null,
      signedIn: false,
    }
  },
  methods:{
    setUser(value){
      this.signedIn = true;
      user = value;
    }
  },
  mounted(){
    
  }
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
.top{
  position: fixed;
  top: 0;
  width: 100%;
}
</style>
