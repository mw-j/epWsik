<template>
    <form>
        <h3>Forgot Password</h3>
        <div class="form-group">
            <label>Email</label>
            <input type="email" v-model="email" class="form-control" placeholder="Email" />
        </div>
        <button class="btn btn-primary btn-block">Submit</button>
    </form>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import axios from 'axios';

    export default defineComponent({
        name: 'ForgotPassword',
        data() {
            return {
                email: ''
            }
        },
        methods: {
            handleSubmit() {
                axios.post('forgot', {
                    email: this.email
                });
            }
        }
    });
</script>