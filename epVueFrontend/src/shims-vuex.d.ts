import store from './vuex';

declare module '@vue/runtime-core' {
    interface ComponentCustomProperties {
        $store: store;
    }
}