<template>
<div class="currentView">
  <router-view></router-view>
</div>
</template>

<script>

export default {
  name: 'App',
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
