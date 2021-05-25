<template>
  <div class="nav-bar">
    <NavBar />
  </div>
  <div class="container-fluid">
    <table class="table table-striped">
      <thead>
        <tr>
          <th scope="col">Name</th>
          <th scope="col">Breed</th>
          <th scope="col">Serial Number</th>
          <th scope="col">Visual Description</th>
          <th scope="col">Allergies</th>
          <th scope="col">Actions</th>
        </tr>
      </thead>

      <tbody>
        <tr v-for="pet in pets" :key="pet.petId">
          <td>{{ pet.name }}</td>
          <td>{{ pet.breed }}</td>
          <td>{{ pet.tagSerialNumber }}</td>
          <td>{{ getDescription(pet.visualDescription) }}</td>
          <td>{{ pet.allergies }}</td>
          <td>
            <button
              type="button"
              class="btn btn-outline-primary"
              @click="showPetDetails(pet)"
            >
              Edit
            </button>
          </td>
        </tr>
      </tbody>
    </table>
    <div id="pet-details" v-if="selectedPet != null">
      <PetDetails :selectedPet="selectedPet" @close="showPetDetails" />
    </div>
  </div>
</template>

<script>
import NavBar from "../components/NavBar";
import PetDetails from "../components/PetDetailsModal";
import { mapActions } from "vuex";

export default {
  computed: {
    pets() {
      return this.$store.state.pets.userPets;
    },
  },

  data() {
    return {
      showPetDetailsModal: false,
      selectedPet: null,
    };
  },
  methods: {
    ...mapActions({
      getPets: "pets/getAllPets",
    }),

    getDescription(description) {
      //Shortens the description and returns it
      if (description.length > 50) {
        return description.substring(0, 50) + "..";
      } else {
        return description;
      }
    },

    showPetDetails(pet) {
      if (this.showPetDetailsModal) {
        if (this.selectedPet === pet) {
          this.showPetDetailsModal = false;
          this.selectedPet = null;
        } else {
          this.selectedPet = pet;
        }
      } else {
        this.showPetDetailsModal = true;
        this.selectedPet = pet;
      }
    },
  },
  mounted() {
    this.pets = [];
    this.getPets();
  },

  components: {
    NavBar,
    PetDetails,
  },
};
</script>

<style scoped>
* {
  margin: 0;
  padding: 0;
}

.navbar {
  position: fixed;
  top: 0;
  width: 100%;
}

td button {
  padding: 1px 5px;
}

#pet-details {
  position: fixed;
  width: 70%;
  background: white;
  top: 60px;
  margin: 5px;
}
</style>