<template>
<div class="calendar">
<AppointmentCalendar/>
</div>
</template>

<script>
import AppointmentCalendar from '../components/AppointmentCalendar'
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
  z-index: 1;
  margin: 0;
  padding: 0;
}
</style>