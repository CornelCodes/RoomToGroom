<template>
  <div class="nav-bar">
    <NavBar :isHome="isActive" />
  </div>
  <div class="calendar">
    <VueCal />
  </div>
</template>

<script>
import VueCal from "../components/VueCal";
import NavBar from "../components/NavBar";

export default {
  data() {
    return {
      //Controls the navbar
      isActive: false,

      customers: [],
    };
  },
  methods: {},
  components: {
    VueCal,
    NavBar,
  },
  created() {
    this.isActive = true;
  },
  destroyed() {
    this.isActive = false;
  },
};
</script>

<style scoped>
* {
  margin: 0;
  padding: 0;
}

.calendar {
  z-index: 0;
}

.navbar {
  z-index: 10000;
  position: fixed;
  top: 0;
  width: 100%;
  height: 8rem;
  margin: 1px;
  padding: 1px;
}
</style>