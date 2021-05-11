<template>
<div class="container">
  <form>
  <div class="form-row">
    <div class="col">
      <input type="text" class="form-control" placeholder="Enter Email">
    </div>
    <div class="col">
      <input type="text" class="form-control" placeholder="Enter Password">
    </div>
    <div class="col">
        <button type="button" class="btn btn-dark">Submit</button>
    </div>
  </div>
</form>
</div>
</template>

<script>
export default {
data(){
    return{
        email: null,
        password: null
    }
}
}
</script>

<style scoped>
.form-row .col{
    width: 60%;
    margin: 2px;
}

.container{
    width: 100%;
    position: fixed;
    left: 20%;
    top: 40%;
}
</style>