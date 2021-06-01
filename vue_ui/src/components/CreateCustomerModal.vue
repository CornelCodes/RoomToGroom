<template>
  <div class="create-customer-form">
    <div class="header">
      <h2>Create Customer</h2>
    </div>
    <div class="row">
      <div class="col-3" id="labels">
        <div class="row" id="name">Name</div>
        <div class="row" id="surname">Surname</div>
        <div class="row" id="email">Email</div>
        <div class="row" id="contact-number">Contact Number</div>
        <div class="row" id="groom-day">Groom Day</div>
        <div class="row" id="groom-frequency">Groom Frequency</div>
      </div>
      <div class="col-7">
        <div class="form-group">
          <div class="row" id="name">
            <input
              type="text"
              class="form-control"
              placeholder="Enter name"
              v-model="newCustomer.name"
            />
          </div>
          <div class="row" id="surname">
            <input
              type="text"
              class="form-control"
              placeholder="Enter surname"
              v-model="newCustomer.surname"
            />
          </div>
          <div class="row" id="email">
            <input
              type="text"
              class="form-control"
              placeholder="Enter email"
              v-model="newCustomer.email"
            />
          </div>
          <div class="row" id="contact-number">
            <input
              type="text"
              class="form-control"
              placeholder="Enter contact number"
              v-model="newCustomer.contactNumber"
            />
          </div>
          <div class="row">
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
          </div>
          <div class="row">
            <select
              name="groom-frequency"
              id="groom-frequency-dropdown"
              v-model="newCustomer.groomFrequency"
            >
              <option value="EveryWeek">Every Week</option>
              <option value="EveryOtherWeek">Every Other Week</option>
              <option value="FirstWeekEachMonth">First Week Each Month</option>
            </select>
          </div>
        </div>
      </div>

      <div class="actions">
        <button
          id="create"
          type="button"
          class="btn btn-primary"
          @click="createCustomer"
        >
          Create
        </button>
        <button
          id="cancel"
          type="button"
          class="btn btn-danger"
          @click="cancel"
        >
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

.header {
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
  font-size: x-large;
  padding: 15px;
  margin: 1px;
}

.create-customer-form {
  background: #f4f4f3;
  color: #111e4c;
  border: 1px solid #111e4c;
  margin: 1px;
  padding: 15px;
}

#groom-frequency-dropdown {
  margin: 1px;
}

#groom-days-dropdown {
  margin: 1px;
}

#name {
  display: block;
  text-align: right;
  margin: 2px 2px;
  padding: 1px;
}
#surname {
  display: block;
  text-align: right;
  margin: 1px 2px;
  padding: 1px;
}
#email {
  display: block;
  text-align: right;
  margin: 2px 2px;
  padding: 1px;
}
#contact-number {
  display: block;
  text-align: right;
  margin: 1px;
  padding: 1px;
}
#groom-day {
  display: block;
  text-align: right;
  margin: 1px;
  padding: 1px;
}
#groom-frequency {
  display: block;
  text-align: right;
  margin: -1px 1px 0 0;
}

.actions #create {
  margin: 1px;
  padding: 5px;
}

.actions #cancel {
  margin: 1px;
  padding: 5px;
}
</style>