<template>
<div class="header">
  <img class="logo" src="@/assets/image1.png" alt="logo">
  <nav>
    <ul class="nav_links">
      <li><a href="#">Home</a></li>
      <li><a href="#">Customers</a></li>
      <li><a href="#">Pets</a></li>
    </ul>
  </nav>
  <div v-if="signedIn">
    <a class="cta" href="#"><button type="button">Sign Out</button></a>
  </div>
  <div v-else>
    <a class="cta" href="#"><button type="button">Sign In</button></a>
  </div>
</div>
</template>

<script>
export default {
data(){
  return{
    signedIn: false,
  }
}
}
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@500&display=swap');
* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
  background-color: #24252a;
}

li, a, button{
  font-family: "Montserrat", sans-serif;
  font-weight: 500;
  font-size: 16px;
  color: #edf0f1;
  text-decoration: none;
}

.header{
  position: fixed;
  top: 0;
  left: 0;
  height: 120px;
  width: 100vw;
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 30px 10%;
}

.logo{
  width: 100px;
  height: 100px;
  cursor: pointer;
}

.nav_links{
  list-style: none;
}

.nav_links li{
  display: inline-block;
  padding: 0 20px;
}

.nav_links li a{
  transition: all 0.3s ease 0s;
}

.nav_links li a:hover{
  color: #0088a9;
}

button {
  padding: 9px 25px;
  background-color: rgba(0, 136, 169, 1);
  border: none;
  border-radius: 50px;
  cursor: pointer;
  transition: all 0.3s ease 0s;
}

button:hover{
  background-color: rgba(0, 136, 169, 0.8);
}
</style>