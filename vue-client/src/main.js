import Vue from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import App from './App.vue'

Vue.config.productionTip = false

new Vue({
  render: h => h(App),
}).use(VueAxios, axios).$mount('#app')
