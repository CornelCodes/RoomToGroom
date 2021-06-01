<template>
  <div class="nav-bar">
    <NavBar @filter="filter" />
  </div>

  <div class="container-fluid" id="list">
    <table class="table table-striped">
      <thead>
        <tr>
          <th scope="col">Name</th>
          <th scope="col">Surname</th>
          <th scope="col">Contact No</th>
          <th scope="col">Email</th>
          <th scope="col">Actions</th>
        </tr>
      </thead>

      <tbody>
        <tr v-for="customer in filteredCustomers" :key="customer.customerId">
          <td>{{ customer.name }}</td>
          <td>{{ customer.surname }}</td>
          <td>{{ customer.contactNumber }}</td>
          <td>{{ customer.email }}</td>
          <td id="edit">
            <button
              type="button"
              class="btn btn-outline-primary"
              @click="editCustomer(customer)"
            >
              Edit
            </button>
            <button
              type="button"
              class="btn btn-outline-danger"
              @click="deleteCustomer(customer)"
              id="edit"
            >
              Delete
            </button>
          </td>
        </tr>
      </tbody>
    </table>

    <div class="create-modal" v-if="showCreateCustomer">
      <CreateCustomerModal @close="closeCreateCustomer" />
    </div>

    <div class="sticky">
      <div class="create">
        <button
          type="button"
          class="btn btn-primary"
          @click="toggleShowCreateCustomer"
          :disabled="showCreateCustomer"
        >
          Create Customer
        </button>
      </div>
    </div>

    <div class="edit-modal" v-if="showEditCustomer">
      <CustomerDetailsModal
        @close="closeEditCustomer"
        :customer="customerToEdit"
      />
    </div>
  </div>
</template>

<script>
import NavBar from "../components/NavBar";
import CustomerDetailsModal from "../components/CustomerDetailsModal";
import CreateCustomerModal from "../components/CreateCustomerModal";
import { mapActions } from "vuex";

export default {
  computed: {
    customers() {
      return this.$store.state.customers.userCustomers;
    },

    filteredCustomers() {
      return this.customers.filter((customer) => {
        return customer.name.toUpperCase().match(this.searchText.toUpperCase());
      });
    },
  },

  data() {
    return {
      selectedCustomer: null,
      showCreateCustomer: false,
      showEditCustomer: false,
      customerToEdit: null,
      searchText: "",
    };
  },

  components: {
    NavBar,
    CustomerDetailsModal,
    CreateCustomerModal,
  },

  methods: {
    ...mapActions({
      getAll: "customers/getAllCustomers",
      delete: "customers/delete",
      update: "customers/update",
      create: "customers/create",
    }),

    filter(searchText) {
      this.searchText = searchText;
      console.log(this.searchText);
    },

    closeEditCustomer() {
      this.showEditCustomer = false;
      this.customerToEdit = null;
    },

    closeCreateCustomer() {
      this.showCreateCustomer = false;
    },

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

    deleteCustomer(customer) {
      this.delete(customer.customerId);
    },

    updateCustomer() {
      this.update();
    },

    createCustomer() {
      this.create(this.newCustomer);
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
    this.getAll();
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
  margin: 1px;
}

.navbar {
  position: fixed;
  z-index: 10000;
  top: 0;
  width: 100%;
  height: 20%;
  margin: 1px;
  padding: 1px;
}

.create-modal {
  position: absolute;
  left: 25%;
  top: 60px;
  width: 50%;
  min-width: 380px;
  background: white;
}

.edit-modal {
  position: absolute;
  left: 0;
  top: 60px;
  background: white;
}

#list {
  position: fixed;
  top: 20%;
}

#list table {
  margin: 1%;
  width: 98%;
  background: #1e6fa6;
  color: #f4f4f3;
}

.create button {
  position: fixed;
  right: 20px;
  bottom: 20px;
  padding: 10px;
  margin-right: 5px;
  background-color: #1e6fa6;
}

#list td {
  background: #f4f4f3;
  color: #111e4c;
}
</style>