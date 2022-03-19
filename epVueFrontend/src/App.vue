<template>
  <div>
      <Nav />
      <div class="auth-wrapper">
          <div class="auth-inner">
              <router-view />
          </div>
      </div>
  </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import axios from 'axios';
    import Nav from './components/Nav.vue';

    export default defineComponent({
        name: 'App',
        components: {
            Nav
        },
        created() {
            axios.get('auth/user')
                .then(res => {
                    this.$store.dispatch('user', res.data);
                }).catch(
                    () => console.log("No User is logged in")
                );
        }
    });
</script>

<style>
    * {
        box-sizing: border-box;
    }

    body {
        background: #1c8ef9;
        min-height: 100vh;
        display: flex;
    }

    html, body, #app, #root, .auth-wrapper {
        width: 100%;
        height: 100%;
    }

    #app {
        text-align: center;
    }

    .navbar-light {
        display: flex;
        justify-content: center;
        flex-direction: column;
        text-align: left;
        background: #fff;
        margin-bottom: 40px;
    }

    .auth-inner {
        width: 450px;
        margin: auto;
        background: #fff;
        padding: 40px;
        border-radius: 15px
    }

</style>
