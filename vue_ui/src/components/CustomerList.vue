<template>
  <div class="container" id="header">
  <div class="customer-list">
    Customer List
  </div>
  <div class="selected-customer">
    Selected Customer
  </div>
</div>
<div class="container" id="content">
  <div class="list">
    <ul class="list-group" id="customers">
      <li class="list-group-item" v-for="customer in customers" :key="customer.name" @click="getSelectedCustomer(customer)">{{customer.name}} {{customer.surname}}
        <button type="button" class="btn btn-outline-secondary">Edit</button>
      </li>
    </ul>
  </div>
  <div class="overview">
    <ul v-if="selectedCustomer != null">
      <li>Name:{{selectedCustomer.name}}</li>
      <li>Surname:{{selectedCustomer.surname}}</li>
      <li>Email:{{selectedCustomer.email}}</li>
      <li>Contact No:{{selectedCustomer.contactNumber}}</li>
      <li>Customer Since:{{selectedCustomer.customerSince}}</li>
      <li>Groom Day:{{selectedCustomer.groomDay}}</li>
      <li>Groom Frequency:{{selectedCustomer.groomFrequency}}</li>
    </ul>
  </div>
</div>
</template>

<script>
export default {

}
</script>

<style>

</style>