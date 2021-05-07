<template>
  <div class="container">
      <vue-cal 
      :time="false"
      :disable-views="['years', 'year']">
      </vue-cal>
      <div class="appointmentOverview">
          <div class="grid-container">
              <div class="grid-header">Overview</div>
              <ul v-for="appointment in appointments" :key="appointment.AppointmentId">
                  <li>
                      {{appointment.time}}
                      {{appointment.description}}
                  </li>
              </ul>
              <div class="addButton">
                  <button type="button">Add</button>
              </div>
          </div>
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
.addButton{
    position: fixed;
    bottom: 20px;
    right: 10px;
}
.container{
    position: fixed;
    top: 130px;
    left: 0;
    float: left;
    width: 80%;
    height: 250px;
}
.appointmentOverview{
    background: black;
    color: white;
    float: right;
    position: fixed;
    right: 0;
    bottom: 0;
    margin: 0 0 10px 0;
    padding: 10px 0 10px 0;
    width: 20%;
    height: 70%;
    border: 1px solid black;
}
.grid-header{
    text-align: center;
    background: grey;
    margin: 0;
    padding: 0;
    border-bottom: 1px solid white;
    border-width: 100%;
}

</style>