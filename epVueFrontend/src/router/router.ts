import { createRouter, createWebHistory, RouteRecordRaw} from 'vue-router';

import Home from '../components/Home.vue';
import Login from '../components/User/Login.vue';
import Register from '../components/User/Register.vue';
import ForgotPassword from '../components/User/Forgot.vue';

const routes: Array<RouteRecordRaw> = [
    {
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/login',
        name: 'Login',
        component: Login
    },
    {
        path: '/register',
        name: 'Register',
        component: Register
    }//,
    //{
    //    path: '/forgotPassword',
    //    name: 'ForgotPassword',
    //    component: ForgotPassword
    //}

];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;