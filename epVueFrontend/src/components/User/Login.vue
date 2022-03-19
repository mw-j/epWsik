<template>
    <form @submit.prevent="handleSubmit">
        <h3>Login</h3>

        <div class="form-group">
            <label>Email</label>
            <input type="email" class="form-control" v-model="userLoginDTO.Email" placeholder="Email" />
        </div>

        <div class="form-group">
            <label>Password</label>
            <input type="password" class="form-control" v-model="userLoginDTO.Password" placeholder="Password" />
        </div>

        <button class="btn btn-primary btn-block">Login</button>

        <p class="forgot-password text-right">
            <router-link to="forgotPassword">Forgot password?</router-link>
        </p>

    </form>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import axios from 'axios';
    import { IUserLoginDTO } from '../../types/epAPI/DTOs/IUserLoginDTO';
    
    export default defineComponent({
        name: 'Login',
        data() {
            return {
                userLoginDTO: {
                    Email: '',
                    Password: ''
                } as IUserLoginDTO
            }
        },
        methods: {
            handleSubmit(): void {
                axios.post('auth/login', this.userLoginDTO)
                    .then(
                        res => {
                            console.log(res);
                            localStorage.setItem('jwtToken', res.data.jwtToken);
                            this.$store.dispatch('user', res.data.userDTO);
                            this.$router.push('/');
                        }
                    ).catch(
                        err => {
                            console.log(err);
                        }
                    )
            }
        }
    });
</script>