<template>
<div class="container-fluid">
  <form>
      <div class="form-row">
          <div class="form-group col-md-6">
              <input type="text" v-model="name" class="form-control" placeholder="First Name">
              <input type="text" v-model="surname" class="form-control" placeholder="Last Name">
              <input type="text" v-model="email" class="form-control" placeholder="Email">
              <input type="text" v-model="contactNumber" class="form-control" placeholder="Contact Number">
              <label for="inputDay">Groom Day</label>
              <select id="inputDay" v-model="groomDay" class="form-control">
                <option value='Monday'>Monday</option>
                <option value='Tuesday'>Tuesday</option>
                <option value='Wednesday'>Wednesday</option>
                <option value='Thursday'>Thursday</option>
                <option value='Friday'>Friday</option>
                <option value='Saturday'>Saturday</option>
                <option value='Sunday'>Sunday</option>
              </select>
              <div class="form-check">
                <input v-model="groomFrequency" class="form-check-input" type="radio" name="frequencyRadio" id="everyWeek" value="EveryWeek">
                <label class="form-check-label" for="everyWeek">Every Week</label>
              </div>
              <div class="form-check">
                <input v-model="groomFrequency" class="form-check-input" type="radio" name="frequencyRadio" id="everyOtherWeek" value="EveryOtherWeek">
                <label class="form-check-label" for="everyOtherWeek">Every Other Week</label>
              </div>
              <div class="form-check">
                <input v-model="groomFrequency" class="form-check-input" type="radio" name="frequencyRadio" id="onceAMonth" value="FirstWeekEachMonth">
                <label class="form-check-label" for="firstWeekEachMonth">First Week Each Month</label>
              </div>
          </div>
      </div>
      <div class="col-sm-10">
        <button type="button" class="btn btn-primary" @click="createCustomer">Create</button>
      </div>
  </form>
</div>
</template>

<script>
export default {
data(){
  return{
    customer:{
      groomerId: 1,
      name: '',
      surname: '',
      email: '',
      contactNumber: '',
      groomDay: '',
      groomFrequency: ''
    },
    showModal: false
  }
},
props:{
},
methods:{
  createCustomer(){
    console.log(this.groomDay)
    console.log(this.groomFrequency)
    var base = this;
    var newCustomer = {
      "GroomerId": base.groomerId,
      "Name": base.name,
      "Surname": base.surname,
      "Email": base.email,
      "ContactNumber": base.contactNumber,
    }
    var headers = {
      "Content-Type": "application/json"
    }

    axios.post('api/Customer', newCustomer, {headers:headers})
    .then(res => {
      console.log("Received: " + res)
      this.showModal = false;
    })
    .catch(err => {
      console.log("Error: " + err)
    })
  },
},
}
</script>

<style scoped>
.container{
    padding: 10px;
    border: 1px solid black;
    display: block;
    width: 90%;
}

</style>