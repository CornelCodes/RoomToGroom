<template>
  <div class="container-fluid">
    <div id="edit-modal">
      <div class="actions">
        <div id="close">
          <button
            id="close"
            type="button"
            class="btn btn-outline-danger"
            @click="closeEditModal"
          >
            X
          </button>
        </div>

        <div id="add-pet">
          <button
            type="button"
            class="btn btn-primary"
            @click="toggleShowCreatePet"
          >
            Add Pet
          </button>
        </div>
      </div>

      <div class="row" id="full-name">
        <h1>{{ customer.name }} {{ customer.surname }}</h1>
      </div>
      <div class="row"></div>

      <div class="row" id="email">
        <h5>Email: {{ customer.email }}</h5>
      </div>
      <div class="row"></div>

      <div class="row" id="contact-number">
        <h5>Contact Number: {{ customer.contactNumber }}</h5>
      </div>

      <div class="row" id="customer-since">
        Customer Since: {{ customer.customerSince }}
      </div>

      <div class="row" id="groom-day">
        <h5>Groom Day:{{ customer.groomDay }}</h5>
      </div>

      <div class="row" id="groom-frequency">
        <h5>Groom Frequency:{{ customer.groomFrequency }}</h5>
      </div>

      <div id="pet-list">
        <h5>Pets:</h5>
        <ul class="list-group" v-for="pet in pets" :key="pet.petId">
          <li class="list-group-item" @click="toggleShowPetDetails(pet)">
            {{ pet.name }}
          </li>
        </ul>
      </div>
    </div>

    <div id="pet-details" v-if="showPetDetails">
      <PetDetailsModal @close="closePetDetails" :selectedPet="selectedPet" />
    </div>

    <div id="create-pet" v-if="showCreatePet">
      <CreatePetModal
        @close="toggleShowCreatePet"
        :customerId="customer.customerId"
      />
    </div>
  </div>
</template>

<script>
import PetDetailsModal from "./PetDetailsModal";
import CreatePetModal from "./CreatePetModal";

export default {
  computed: {
    pets() {
      var pets = this.$store.state.pets.userPets;
      var customerPets = [];

      pets.forEach((pet) => {
        if (pet.customerId === this.customer.customerId) {
          customerPets.push(pet);
        }
      });

      return customerPets;
    },
  },

  props: {
    customer: {
      name: String,
      surname: String,
      email: String,
      contactNumber: String,
      customerSinceDate: Date,
      groomDay: Number,
    },
  },

  components: {
    PetDetailsModal,
    CreatePetModal,
  },

  data() {
    return {
      showPetDetails: false,
      showCreatePet: false,
      selectedPet: null,
      customerSinceDate: null,
    };
  },

  methods: {
    getPets() {
      axios
        .get("api/Pet/GetByCustomerId", {
          customerId: this.customer.customerId,
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${localStorage.getItem("token")}`,
          },
        })
        .then((res) => {
          this.pets = res.data;
          console.log("Success");
        })
        .catch((err) => {
          console.log(err);
        });
    },

    toggleShowPetDetails(pet) {
      if (this.showPetDetails === false) {
        this.selectedPet = pet;
        this.showPetDetails = true;
      } else {
        if (this.selectedPet != pet) {
          this.selectedPet = pet;
        } else {
          this.showPetDetails = false;
        }
      }
      console.log(this.showPetDetails);
    },

    getCustomerSinceDate() {
      var dateTimeString = this.customer.customerSinceDate;
      var dateTimeStringArr = dateTimeString.split("T");
      this.customerSinceDate = dateTimeStringArr[0];
      console.log("Split date to " + dateTimeStringArr[0]);
    },

    closePetDetails() {
      this.showPetDetails = false;
    },

    toggleShowCreatePet() {
      this.showCreatePet = !this.showCreatePet;
      console.log(this.showCreatePet);
    },

    closeEditModal() {
      this.$emit("close");
    },
  },

  mounted() {
    console.log("updated");
    this.getPets();
    // this.getCustomerSinceDate();
  },
};
</script>

<style scoped>
* {
  margin: 0;
  padding: 0;
}

#edit-modal {
  position: fixed;
  top: 20%;
  margin: 1px;
  width: 50%;
  height: auto;
  background: white;
  border: 1px solid black;
}

#pet-details,
#create-pet {
  position: fixed;
  top: 20%;
  margin-right: 5px;
  margin-top: 1px;
  right: 0;
  width: 49%;
  height: auto;
  background: white;
}

#full-name {
  text-align: left;
  margin: 2px;
  padding: 16px;
}

#email {
  text-align: left;
  margin: 2px;
  padding: 16px;
}
#contact-number {
  text-align: left;
  margin: 2px;
  padding: 5px 16px;
}
#email {
  text-align: left;
  margin: 2px;
  padding: 5px 16px;
}

#customer-since {
  text-align: left;
  margin: 2px;
  padding: 5px 16px;
}
#groom-day {
  text-align: left;
  margin: 2px;
  padding: 5px 16px;
}
#groom-frequency {
  text-align: left;
  margin: 2px;
  padding: 5px 16px 10px;
}

#pet-list {
  height: 200px;
}

#pet-list h5 {
  text-align: left;
  margin: 2px;
  padding: 10px 16px 10px;
}

#pet-list ul {
  margin: 5px 10px;
}

.actions button {
  margin: 5px;
  padding: 5px;
}

#close button {
  float: right;
}

#add-pet button {
  position: absolute;
  bottom: 0;
  left: 0;
}
</style>