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
          <td>{{ pet.visualDescription }}</td>
          <td>{{ pet.allergies }}</td>
          <td>
            <button type="button" class="btn btn-outline-primary">Edit</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import NavBar from "../components/NavBar";
import { mapActions } from "vuex";

export default {
  computed: {
    pets() {
      return this.$store.state.pets.userPets;
    },
  },

  data() {
    return {};
  },
  methods: {
    ...mapActions({
      getPets: "pets/getAllPets",
    }),
  },
  beforeUpdate() {
    this.pets = [];
    this.getPets();
  },

  components: {
    NavBar,
  },
};
</script>

<style scoped>
table,
th,
td {
  border: 1px solid black;
}

.navbar {
  position: fixed;
  top: 0;
  width: 100%;
}

td button {
  padding: 1px 5px;
}
</style>