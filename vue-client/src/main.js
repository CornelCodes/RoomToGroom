import Vue from 'vue'
import axios from 'axios'
import App from './App.vue'

Vue.config.productionTip = false
window.axios = axios
axios.defaults.baseURL = 'https://localhost:5001'

new Vue({
  render: h => h(App),
}).use(VueAxios, axios).$mount('#app')
