<template>
  <div class="container-fluid" id="modal">
    <div class="row" id="header">
      <h5>Create New Pet</h5>
    </div>
    <div class="row" id="name">
      <input
        type="text"
        class="form-control"
        placeholder="Name"
        v-model="newPet.name"
      />
    </div>
    <div class="row" id="breed">
      <input
        type="text"
        class="form-control"
        placeholder="Breed"
        v-model="newPet.breed"
      />
    </div>
    <div class="row" id="serial-number">
      <input
        type="text"
        class="form-control"
        placeholder="Tag Serial Number:"
        v-model="newPet.tagSerialNumber"
      />
    </div>
    <div class="row" id="description">
      <h5>Description:</h5>
      <textarea v-model="newPet.visualDescription"></textarea>
    </div>
    <div class="row" id="allergies">
      <h5>Allergies:</h5>
      <textarea v-model="newPet.allergies"></textarea>
    </div>
    <div class="row" id="actions">
      <button type="button" class="btn btn-primary" @click="createPet">
        Create
      </button>
      <button type="button" class="btn btn-danger" @click="cancel">
        Cancel
      </button>
    </div>
  </div>
</template>

<script>
import { mapActions } from "vuex";

export default {
  props: {
    customerId: Number,
  },
  data() {
    return {
      newPet: {
        name: "",
        breed: "",
        tagSerialNumber: "",
        visualDescription: "",
        allergies: "",
        customerId: this.customerId,
      },
    };
  },

  methods: {
    ...mapActions({
      create: "pets/create",
    }),

    cancel() {
      this.$emit("close");
    },

    createPet() {
      console.log(this.newPet);
      this.create(this.newPet)
        .then(() => {
          this.$emit("close");
        })
        .catch((err) => {
          console.log(err);
        });
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
  width: 45%;
  margin: 5px;
}

#serial-number input {
  width: 45%;
  margin: 5px;
}

#breed input {
  width: 45%;
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