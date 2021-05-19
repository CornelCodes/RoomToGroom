<template>
<div class="nav-bar">
  <NavBar :isHome='isActive'/>
</div>
<div class="calendar">
<AppointmentCalendar/>
</div>
</template>

<script>
import AppointmentCalendar from '../components/AppointmentCalendar'
import NavBar from '../components/NavBar'

export default {
data(){
  return{
    isActive: false,
  }
},
methods:{
},
components:{
  AppointmentCalendar,
  NavBar,
},
created(){
this.isActive = true;
},
destroyed(){
this.isActive = false;
}
}
</script>

<style scoped>
*{
  z-index: 1;
  margin: 0;
  padding: 0;
}

.navbar{
  position: fixed;
  top: 0;
  width: 100%;
}
</style>