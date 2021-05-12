<template>
    <div class="container-fluid">
      <div class="table-responsive">
        <table class="table">
          <tr>
            <th>Name</th>
            <th>Breed</th>
            <th>Serial No:</th>
            <th>Visual Description</th>
            <th>Allergies</th>
            <th>Owner</th>
          </tr>
          <tr v-for="pet in pets" :key="pet.name">
            <td>{{pet.name}}</td>
            <td>{{pet.breed}}</td>
            <td>{{pet.tagSerialNumber}}</td>
            <td>{{pet.visualDescription}}</td>
            <td>{{pet.allergies}}</td>
            <td>{{pet.customerID}}</td>
          </tr>
        </table>
      </div>
    </div>
    <button type="button" class="btn btn-outline-primary">Add</button>
</template>

<script>
export default {
data(){
  return{
    pets: [],
  }
},
methods:{
  getPets(){
    axios.get('api/pet')
    .then(res => {
      this.pets = res.data;
    })
    .catch(err => {
      console.log("Error: " + err)
    })
  }
},
mounted(){
  this.getPets()
}
}
</script>

<style>
table, th, td{
  border: 1px solid black;
}
</style>