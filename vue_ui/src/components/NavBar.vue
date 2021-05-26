<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light" id="nav-bar">
    <div class="container-fluid">
      <div class="logo-container">
        <a class="navbar-brand" href="/" id="logo">
          <img src="../assets/rtg-logo.png" alt="logo" />
        </a>
      </div>
      <button
        class="navbar-toggler"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
          <li class="nav-item">
            <a href="/" class="nav-link">Home</a>
          </li>
          <li class="nav-item">
            <a href="Pets" class="nav-link">Pets</a>
          </li>
          <li class="nav-item">
            <a href="Customers" class="nav-link">Customers</a>
          </li>
        </ul>
        <div class="d-flex" v-if="isHome" id="sign-out">
          <button class="btn btn-primary" type="button" @click="signOut">
            Sign Out
          </button>
        </div>
        <form class="d-flex" v-else id="search">
          <input
            class="form-control me-2"
            type="search"
            placeholder="Search"
            aria-label="Search"
          />
          <button class="btn btn-primary" type="submit">Search</button>
        </form>
      </div>
    </div>
  </nav>
</template>

<script>
import { mapActions } from "vuex";
export default {
  props: {
    isHome: Boolean,
  },
  data() {
    return {
      user: {},
    };
  },
  methods: {
    ...mapActions({
      logOut: "auth/logOut",
    }),

    async signOut() {
      await this.logOut();
      this.$router.push("/Login");
    },
  },
  mounted() {
    console.log("Mounted");
    this.user = JSON.parse(localStorage.getItem("user"));
    console.log(this.user);
  },
};
</script>

<style scoped>
* {
  margin: 0;
  padding: 0;
}

#nav-bar {
  position: fixed;
  background: #f4f4f3;
}

#nav-bar a {
  color: #111e4c;
  font-size: 25px;
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
}

#sign-out {
  margin: 0 1%;
}

#sign-out button {
  margin: 10px 20px;
  padding: 5px;
  background: #1e6fa6;
  color: #f4f4f3;
}

#search button {
  margin: 10px 20px 10px 0;
  padding: 5px;
  background: #1e6fa6;
  color: #f4f4f3;
}

#search input {
  margin: 10px;
}

.login {
  position: fixed;
  left: 50%;
  top: 50%;
}

#logo img {
  display: flex;
  width: 100px;
  height: 100px;
  margin: 0 50px 0 50px;
}
</style>