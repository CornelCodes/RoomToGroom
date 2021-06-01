<template>
  <div class="container-fluid" id="modal">
    <div class="row">
      <div class="col" id="image">
        <img src="../assets/image-placeholder-dog.png" alt="" />
      </div>
      <div class="col">
        <div class="row">
          <h6>Serial No: {{ selectedPet.tagSerialNumber }}</h6>
        </div>
        <div class="row" id="name">
          <div class="col-2">
            <h6>Name:</h6>
          </div>

          <div class="col-9">
            <input
              type="text"
              class="form-control"
              v-model="selectedPet.name"
            />
          </div>
        </div>

        <div class="row" id="breed">
          <div class="col-2">
            <h6>Breed:</h6>
          </div>
          <div class="col-9">
            <input
              type="text"
              class="form-control"
              v-model="selectedPet.breed"
            />
          </div>
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
          <button
            id="save"
            type="button"
            class="btn btn-outline-primary"
            @click="savePet"
          >
            Save
          </button>
          <button
            id="cancel"
            type="button"
            class="btn btn-outline-danger"
            @click="cancel"
          >
            Cancel
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions } from "vuex";
export default {
  props: {
    selectedPet: {
      name: String,
      breed: String,
      tagSerialNumber: String,
      visualDescription: String,
      allergies: String,
    },
  },

  methods: {
    ...mapActions({
      update: "pets/update",
    }),

    cancel() {
      this.$emit("close");
    },

    savePet() {
      this.selectedPet;
      this.update(this.selectedPet);
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
  border: 1px solid #111e4c;
  padding: 5px;
}

#image img {
  width: 90%;
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
  margin: 25% 5px 10px 5px;
  padding: 5px;
}
</style>