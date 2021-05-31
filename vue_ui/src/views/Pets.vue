<template>
  <div class="nav-bar">
    <NavBar />
  </div>
  <div class="container-fluid" id="list">
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
            <button
              type="button"
              class="btn btn-outline-danger"
              @click="removePet(pet.petId)"
            >
              Delete
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
      remove: "pets/remove",
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

    removePet(petId) {
      this.remove(petId).then(() => {
        this.getPets();
      });
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
  height: 20%;
  margin: 1px;
  padding: 1px;
}

td button {
  margin: 2px;
  padding: 1px 5px;
}

#pet-details {
  position: fixed;
  width: 60%;
  min-width: 445px;
  background: white;
  top: 120px;
}

#list {
  margin: 130px 1%;
  width: 98%;
}

#list table {
  background: #1e6fa6;
  color: #f4f4f3;
}

#list td {
  background: #f4f4f3;
  color: #111e4c;
}
</style>