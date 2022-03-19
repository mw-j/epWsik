import axios from 'axios';

axios.defaults.baseURL = 'https://localhost:7012';
axios.defaults.headers.common['Authorization'] = 'Bearer ' + localStorage.getItem('jwtToken');