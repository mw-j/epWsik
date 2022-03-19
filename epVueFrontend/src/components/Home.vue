<template>
    <h3 v-if="user">Hi, {{user.firstName}} {{user.lastName}}</h3>
    <h3 v-else>You are not logged in</h3>
    <Button>Test</Button>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import { mapGetters } from 'vuex';
    import Button from 'primevue/button';

    export default defineComponent({
        name: 'Home',
        components: {
            Button
        },
        computed: {
            ...mapGetters(['user'])
        }
    });
</script>