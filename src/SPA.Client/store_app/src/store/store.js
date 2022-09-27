import { createStore } from 'vuex'

export default createStore({
    state: {
        sessionToken: '',
        user: {
            firstName: null,
            lastName: null,
            role: null
        },
        apiUrl: '',
        isLogged: false
    },

    mutations: {

        setConfig(state, configUrl) {
            localStorage.setItem('config', JSON.stringify(configUrl));
            state.apiUrl = configUrl;
        },
        setUserToken(state, token) {
            localStorage.setItem('token', JSON.stringify(token));
            state.sessionToken = token;
        },
        setUserInfo(state, value) {
            console.log("🚀 ~ file: store.js ~ line 26 ~ setUserInfo ~ state", state)

            var splitToken = value.split('.')
            var userInfo = window.atob(splitToken[1]);
            console.log("🚀 ~ file: store.js ~ line 29 ~ setUserInfo ~ userInfo", userInfo)
            var user = JSON.parse(userInfo)
            state.user = {
                firstName: user.unique_name,
                lastName: user.family_name,
                role: user.role
            }

        },
        setIsLogged(state, value) {
            state.isLogged = value;
        }
    },
    actions: {
        saveToken({ commit }, value) {
            commit("setUserToken", value);
            commit("setUserInfo", value);
        },
        urlConfig({ commit }, value) {
            commit("setConfig", value)
        }
    },
    getters: {
        getToken() {
            var token = localStorage.getItem('token');
            if (!token) {
                return null
            }
            return JSON.parse(token);
        },
        getUser() {
            var token = localStorage.getItem('token')
            if (!token) {
                return null;
            }
            var splitToken = JSON.parse(token).split('.')
            var userInfo = window.atob(splitToken[1]);
            var user = JSON.parse(userInfo)
            

            return user ? {userName: user.unique_name, lastName:user.family_name, role:user.role} : null
        },
        getUrl: (state) => state.apiUrl,
        getIsLogged: () => {
            var token = localStorage.getItem('token');
            if (token)
                return true;

            return false;
        }

    }



})