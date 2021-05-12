<template>
<div class="container-fluid">
    <div class="row">
        <div class="col-9">
            <div class="calendar">
                <vue-cal 
                :time="false"
                :disable-views="['years', 'year']">
                </vue-cal>
            </div>
        </div>
        <div class="col-3">
            <div class="appointment-list">
                <ul class="list-group">
                    <li class="list-group-item">Test Appointment</li>
                    <li class="list-group-item">Test Appointment</li>
                    <li class="list-group-item">Test Appointment</li>
                    <li class="list-group-item">Test Appointment</li>
                    <li class="list-group-item">Test Appointment</li>
                    <button type="button" class="btn btn-primary">Add</button>
                </ul>
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

.calendar{
    height: 100%;
    width: 100%;
}

.appointment-list li{
    font-size: small;
    text-align: center;
    width: 100%;
    margin: 1px;
    padding: 1px;
}

</style>