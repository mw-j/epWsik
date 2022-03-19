<template>
    <form @submit.prevent="handleSubmit">
        <h3>Register</h3>

        <div class="form-group">
            <label>First Name</label>
            <input type="text" class="form-control" v-model="userRegisterDTO.FirstName" placeholder="First Name" />
        </div>

        <div class="form-group">
            <label>Last Name</label>
            <input type="text" class="form-control" v-model="userRegisterDTO.LastName" placeholder="Last Name" />
        </div>

        <div class="form-group">
            <label>Email</label>
            <input type="email" class="form-control" v-model="userRegisterDTO.Email" placeholder="Email" />
        </div>

        <div class="form-group">
            <label>Password</label>
            <input type="password" class="form-control" v-model="userRegisterDTO.Password" placeholder="Password" />
        </div>

        <button class="btn btn-primary btn-block">Sign up</button>

    </form>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import axios from 'axios';
    import { IUserRegisterDTO } from '../../types/epAPI/DTOs/IUserRegisterDTO';

    export default defineComponent({
        name: 'Register',
        data() {
            return {
                userRegisterDTO: {
                    Email: '',
                    Password: '',
                    FirstName: '',
                    LastName: ''
                } as IUserRegisterDTO,
            }
        },
        methods: {
            handleSubmit(): void {
                axios.post('auth/register', this.userRegisterDTO)
                    .then(
                        () => {
                            this.$router.push('/login');
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