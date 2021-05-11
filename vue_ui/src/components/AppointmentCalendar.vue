<template>
  <div class="container">
      <div class="calendar">
        <vue-cal 
        :time="false"
        :disable-views="['years', 'year']">
        </vue-cal>
      </div>
      <div class="appointment-list">
          <ul class="list-group">
              <li class="list-group-item">Test Appointment</li>
              <li class="list-group-item">Test Appointment</li>
              <li class="list-group-item">Test Appointment</li>
              <li class="list-group-item">Test Appointment</li>
              <li class="list-group-item">Test Appointment</li>
          </ul>
      </div>
  </div>
</template>

<script>
import VueCal from 'vue-cal'
import 'vue-cal/dist/vuecal.css'
export default {
components:{
    VueCal,
},
data(){
    return{
        appointmentCount: null,
        appointments: [{
            appointment:{
                time: null,
                description: null,
            }
        }],
    }
},
methods:{
    getAppointments(){
        axios.get('api/Appointment')
        .then(res => {
            if(res != null){
                this.appointments = res.data
            }
        })
    }
},
mounted(){
    this.getAppointments()
}
}
</script>

<style scoped>
*{
    z-index: 0;
}

.calendar{
    width: 80%;
    height: 100%;
}

.appointment-list{
    width: 20%;
    position: absolute;
    right: 1%;
    top: 20%;
    height: 100%;
}

.appointment-list li{
    font-size: small;
    text-align: center;
    width: 100%;
    margin: 0;
    padding: 0;
}

</style>