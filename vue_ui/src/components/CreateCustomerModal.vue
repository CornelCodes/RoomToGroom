<template>
  <div class="create-customer-form">
    <h2>Create Customer</h2>
    <div class="form-group">
      <div class="row" id="name">
        <input
          type="text"
          class="form-control"
          placeholder="Name"
          v-model="newCustomer.name"
        />
      </div>
      <div class="row" id="surname">
        <input
          type="text"
          class="form-control"
          placeholder="Surname"
          v-model="newCustomer.surname"
        />
      </div>
      <div class="row" id="email">
        <input
          type="text"
          class="form-control"
          placeholder="Email"
          v-model="newCustomer.email"
        />
      </div>
      <div class="row" id="contact-number">
        <input
          type="text"
          class="form-control"
          placeholder="Contact Number"
          v-model="newCustomer.contactNumber"
        />
      </div>

      <select
        name="groom-days"
        id="groom-days-dropdown"
        v-model="newCustomer.groomDay"
      >
        <option value="Monday">Monday</option>
        <option value="Tuesday">Tuesday</option>
        <option value="Wednesday">Wednesday</option>
        <option value="Thursday">Thursday</option>
        <option value="Friday">Friday</option>
        <option value="Saturday">Saturday</option>
        <option value="Sunday">Sunday</option>
      </select>

      <select
        name="groom-frequency"
        id="groom-frequency-dropdown"
        v-model="newCustomer.groomFrequency"
      >
        <option value="EveryWeek">Every Week</option>
        <option value="EveryOtherWeek">Every Other Week</option>
        <option value="FirstWeekEachMonth">First Week Each Month</option>
      </select>

      <div class="actions">
        <button type="button" class="btn btn-primary" @click="createCustomer">
          Create
        </button>
        <button type="button" class="btn btn-danger" @click="cancel">
          Cancel
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions } from "vuex";
export default {
  data() {
    return {
      newCustomer: {
        name: "",
        surname: "",
        email: "",
        contactNumber: "",
        groomDay: null,
        groomFrequency: null,
      },
    };
  },

  methods: {
    ...mapActions({
      create: "customers/create",
    }),

    createCustomer() {
      this.create(this.newCustomer)
        .then(() => {
          console.log("Created customer");
          this.$emit("close");
        })
        .catch((err) => {
          console.log(err);
        });
    },

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

#groom-frequency {
  display: flex;
  margin: 2px 20%;
}

#groom-day {
  display: flex;
  margin: 2px 20%;
}

.actions button {
  margin: 30px;
  padding: 15px;
}

.create-customer-form {
  border: 1px solid black;
}

.create-customer-form h2 {
  margin: 10px;
  padding: 10px;
}

.create-customer-form input {
  width: 80%;
  margin: 5px 10%;
}

#groom-frequency-dropdown {
  margin: 30px 0px 5px 50px;
}

#groom-days-dropdown {
  margin: 30px 50px 5px 0px;
}
</style>