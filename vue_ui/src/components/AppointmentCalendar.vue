<template>
  <div class="container-fluid">
    <div class="calendar">
      <vue-cal
        :time="false"
        :disable-views="['years', 'year']"
        class="vuecal--blue-theme"
      >
      </vue-cal>
    </div>
  </div>
</template>

<script>
import VueCal from "vue-cal";
import "vue-cal/dist/vuecal.css";
export default {
  components: {
    VueCal,
  },
  data() {
    return {
      appointmentCount: null,
      appointments: [
        {
          appointment: {
            time: null,
            description: null,
          },
        },
      ],
    };
  },
  methods: {
    getAppointments() {
      axios.get("api/Appointment").then((res) => {
        if (res != null) {
          this.appointments = res.data;
        }
      });
    },
  },
  mounted() {
    this.getAppointments();
  },
};
</script>

<style scoped>
/* Vue-cal styles*/
.calendar {
  position: absolute;
  height: 70%;
  margin: 2.5%;
  bottom: 20px;
  width: 95%;
  color: #1e6fa6;
}

.vuecal__flex {
  background: #f4f4f3;
}
.vuecal__menu,
.vuecal__cell-events-count {
  background-color: #42b983;
}
.vuecal__menu li {
  border-bottom-color: #1e6fa6;
  color: #fff;
}
.vuecal__menu li.active {
  background-color: rgba(255, 255, 255, 0.15);
}
.vuecal__title {
  background-color: #e4f5ef;
}
.vuecal__cell.today,
.vuecal__cell.current {
  background-color: rgba(240, 240, 255, 0.4);
}
.vuecal:not(.vuecal--day-view) .vuecal__cell.selected {
  background-color: rgba(235, 255, 245, 0.4);
}
.vuecal__cell.selected:before {
  border-color: rgba(66, 185, 131, 0.5);
}
</style>