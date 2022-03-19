import { createApp } from 'vue';
import App from './App.vue';
import router from './router/router';
import store from './vuex';
import './axios';
import PrimeVue from 'primevue/config';

createApp(App)
    .use(store)
    .use(router)
    .use(PrimeVue)
    .mount('#app')
