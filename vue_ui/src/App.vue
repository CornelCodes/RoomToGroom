<template>
  <div class="currentView">
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  name: "App",
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #111e4c;
  margin-top: 60px;
  background: #f4f4f3;
}
.top {
  position: fixed;
  top: 0;
  width: 100%;
}
</style>
