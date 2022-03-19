import { createStore }  from 'vuex';

const state = {
    user: {}
};

const store = createStore({
    state,
    // Getting the current state
    getters: {
        user: (state) => {
            return state.user;
        }
    },
    // Changing the current state, but dont change values direct -> call mutation
    actions: {
        user(context, user) {
            context.commit('user', user);
        }
    },
    mutations: {
        user(state, user) {
            state.user = user;
        }
    }
});

export default store;