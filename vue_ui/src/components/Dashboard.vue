<template>
<header>
  <h1>Dashboard</h1>
</header>
<div class="calendar">

</div>
</template>

<script>
export default {
data(){
  return{
    days: [],

  }
},
methods:{
  getAllDays(){
    for(i = 0; i <= 31; i++){

    }
  }
}
}
</script>

<style>
*{
  margin: 0;
  padding: 0;
}
header{
  position: fixed;
  left: 0px;
  top: 120px;
  margin:10px;
  padding: 10px;
  border: 50px;
  border-width: 100px;
}
</style>