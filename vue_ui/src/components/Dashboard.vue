<template>
<header>
</header>
<div class="calendar">
<AppointmentCalendar/>
</div>
</template>

<script>
import AppointmentCalendar from './AppointmentCalendar'
export default {
  props:{
    user: Object,
  },
data(){
  return{

  }
},
methods:{
},
components:{
  AppointmentCalendar
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