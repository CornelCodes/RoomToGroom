<template>
  <div class="nav-bar">
    <NavBar :isHome="isActive" />
  </div>
  <div class="calendar">
    <AppointmentCalendar />
  </div>
</template>

<script>
import AppointmentCalendar from "../components/AppointmentCalendar";
import NavBar from "../components/NavBar";

export default {
  data() {
    return {
      isActive: false,
    };
  },
  methods: {},
  components: {
    AppointmentCalendar,
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
  position: fixed;
  top: 0;
  width: 100%;
  height: 20%;
  margin: 1px;
  padding: 1px;
}
</style>