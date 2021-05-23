<template>
  <div class="nav-bar">
    <NavBar />
  </div>

  <div class="container-fluid">
    <table class="table table-striped">
      <thead>
        <tr>
          <th scope="col">Name</th>
          <th scope="col">Surname</th>
          <th scope="col">Contact No</th>
          <th scope="col">Email</th>
          <th scope="col"></th>
        </tr>
      </thead>

      <tbody>
        <tr v-for="customer in customers" :key="customer.customerId">
          <td>{{ customer.name }}</td>
          <td>{{ customer.surname }}</td>
          <td>{{ customer.contactNumber }}</td>
          <td>{{ customer.email }}</td>
          <td>
            <button
              type="button"
              class="btn btn-primary"
              @click="editCustomer(customer)"
            >
              Edit
            </button>
          </td>
        </tr>
        <tr v-if="showCreateCustomer" class="form-group">
          <td></td>
          <td>
            <input
              type="text"
              class="form-control"
              v-model="newCustomer.name"
              placeholder="Name"
            />
          </td>
          <td>
            <input
              type="text"
              class="form-control"
              v-model="newCustomer.surname"
              placeholder="Surname"
            />
          </td>
          <td>
            <input
              type="text"
              class="form-control"
              v-model="newCustomer.contactNumber"
              placeholder="Contact No"
            />
          </td>
          <td>
            <input
              type="text"
              class="form-control"
              v-model="newCustomer.email"
              placeholder="Email"
            />
          </td>
          <td>
            <button
              type="button"
              class="btn btn-outline-primary"
              @click="createCustomer"
            >
              Add
            </button>
          </td>
        </tr>
      </tbody>
    </table>

    <div class="sticky">
      <div class="create">
        <button
          type="button"
          class="btn btn-outline-primary"
          @click="toggleShowCreateCustomer"
        >
          Create Customer
        </button>
      </div>
    </div>

    <div class="edit-modal" v-if="showEditCustomer">
      <EditModal :customer="customerToEdit" />
    </div>
  </div>
</template>

<script>
import NavBar from "../components/NavBar";
import EditModal from "../components/EditModal";
import { mapActions } from "vuex";

export default {
  computed: {
    customers() {
      return this.$store.state.customers.userCustomers;
    },
  },

  data() {
    return {
      selectedCustomer: null,
      showCreateCustomer: false,
      showEditCustomer: false,
      newCustomer: {
        name: "",
        surname: "",
        contactNumber: "",
        email: "",
      },
      customerToEdit: null,
    };
  },
  components: {
    NavBar,
    EditModal,
  },
  methods: {
    ...mapActions({
      getCustomers: "customers/getAllCustomers",
    }),

    editCustomer(customer) {
      if (this.showEditCustomer) {
        if (this.customerToEdit === customer) {
          this.toggleShowEditCustomer();
          this.customerToEdit = null;
        } else {
          this.customerToEdit = customer;
        }
      } else {
        this.customerToEdit = customer;
        this.toggleShowEditCustomer();
      }
    },

    //Toggles the create customer inputs
    toggleShowCreateCustomer() {
      this.showCreateCustomer = !this.showCreateCustomer;
    },

    toggleShowEditCustomer() {
      this.showEditCustomer = !this.showEditCustomer;
    },
  },

  mounted() {
    this.customers = [];
    this.getCustomers();
  },
};
</script>

<style scoped>
* {
  margin: 0;
  padding: 0;
}

td button {
  padding: 1px 5px;
}

.selected {
  background: blue;
}

.sticky button {
  position: absolute;
  right: 20px;
  bottom: 20px;
  padding: 10px;
}

.container {
  display: flex;
  padding-top: 10px;
}

.customer-list {
  position: fixed;
  left: 0;
  width: 100%;
  height: 100%;
  background: grey;
}

.navbar {
  position: fixed;
  top: 0;
  width: 100%;
}

.edit-modal {
  position: absolute;
  left: 0;
  top: 60px;
  background: white;
}
</style>