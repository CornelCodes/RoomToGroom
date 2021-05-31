import axios from 'axios'

window.axios = axios
axios.defaults.baseURL = 'https://localhost:5001/'

const instance = axios.create({
    baseURL: 'https://localhost:5001/',
    timeout: 1000,
    headers: { 'Authorization': `Bearer: ${localStorage.getItem('token')}` },
    withCredentials: true,
})

export default instance;
