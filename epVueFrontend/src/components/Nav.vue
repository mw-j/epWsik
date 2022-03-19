<template>
    <nav class="navbar navbar-expand navbar-light">
        <div class="container">
            <router-link to="/" class="navbar-brand">Home</router-link>
            <div class="collapse navbar-collapse">
                <ul v-if="!user.userId" class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <router-link to="/login" class="nav-link">Login</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link to="/register" class="nav-link">Sign up</router-link>
                    </li>
                </ul>
                <ul v-else class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <a href="javascript:void(0)" @click="handleClick" class="nav-link">Logout</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import { mapGetters } from 'vuex';

    export default defineComponent({
        name: 'Nav',
        methods: {
            handleClick(): void {
                localStorage.removeItem('jwtToken');
                this.$store.dispatch('user', null);
                this.$router.push('/');
            }
        },
        computed: {
            ...mapGetters(['user']),
        }
    });
</script>