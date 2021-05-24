<template>
  <div class="container-fluid" id="modal">
    <div class="row">
      <div class="col" id="image">
        <img src="../assets/image-placeholder-dog.png" alt="" />
      </div>
      <div class="col">
        <div class="row" id="name">
          <div class="col">
            <h5 contenteditable v-text="selectedPet.name"></h5>
          </div>
          <div class="col">
            <h6>Serial No:{{ selectedPet.tagSerialNumber }}</h6>
          </div>
        </div>

        <div class="row" id="breed">
          <h6 contenteditable v-text="selectedPet.breed"></h6>
        </div>
        <div class="row" id="serialNumber"></div>
        <div class="row" id="description">
          Description:
          <textarea v-model="selectedPet.visualDescription"></textarea>
        </div>
        <div class="row" id="allergies">
          Allergies:
          <textarea v-model="selectedPet.allergies"></textarea>
        </div>
        <div class="row" id="actions">
          <button type="button" class="btn btn-outline-primary">Save</button>
          <button type="button" class="btn btn-outline-danger" @click="cancel">
            Cancel
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    selectedPet: Object,
  },

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
}

#image img {
  width: 85%;
  height: 85%;
}

#name {
  margin: 3px;
  text-align: left;
}

#breed {
  margin: 3px;
  text-align: left;
}

#serialNumber {
  margin: 10px 3px;
  text-align: left;
}

#description {
  margin: 10px 3px;
  text-align: left;
}

#allergies {
  margin: 10px 3px;
  text-align: left;
}

#actions button {
  width: 45%;
  margin: 1% 1% 0 1%;
}
</style>