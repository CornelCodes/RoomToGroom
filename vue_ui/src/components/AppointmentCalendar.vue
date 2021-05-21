<template>
<div class="container-fluid">
            <div class="calendar">
                <vue-cal 
                :time="false"
                :disable-views="['years', 'year']">
                </vue-cal>
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
}

.calendar{
    height: 500px;
    width: 100%;
}
</style>