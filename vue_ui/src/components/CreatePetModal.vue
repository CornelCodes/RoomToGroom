<template>
  <div class="container-fluid" id="modal">
    <div class="row" id="header">
      <h5>Create New Pet</h5>
    </div>
    <div class="row" id="name">
      <input type="text" class="form-control" placeholder="Name" />
    </div>
    <div class="row" id="breed">
      <input type="text" class="form-control" placeholder="Breed" />
    </div>
    <div class="row" id="description">
      <h5>Description:</h5>
      <textarea></textarea>
    </div>
    <div class="row" id="allergies">
      <h5>Allergies:</h5>
      <textarea></textarea>
    </div>
    <div class="row" id="actions">
      <button type="button" class="btn btn-primary">Create</button>
      <button type="button" class="btn btn-danger" @click="cancel">
        Cancel
      </button>
    </div>
  </div>
</template>

<script>
export default {
  methods: {
    cancel() {
      this.$emit("close");
    },
  },
};
</script>

<style scoped>
* {
  margin: 0;
  padding: 0;
}

#modal {
  border: 1px solid black;
  padding: 5px;
  height: 100%;
}

#header {
  text-align: left;
  margin: 3px;
}

#name input {
  width: 50%;
  margin: 5px;
}

#breed input {
  width: 50%;
  margin: 5px;
}

#description {
  text-align: left;
  margin: 3px;
}

#allergies {
  text-align: left;
  margin: 3px;
}

#actions button {
  margin: 20px 25% 10px;
  padding: 5px;
  width: 50%;
}
</style>