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
        isLogged:false
    },
     
    mutations: {
        setUserName(state, user) {
            state.userName = user;
        },
        setConfig(state, configUrl) {
            state.apiUrl = configUrl;
            localStorage.setItem('config', JSON.stringify(configUrl));
        },
        setUserToken(state, token) {
            state.sessionToken = token  
        },
        setIsLogged(state,value){
            state.isLogged = value;
        }
    },
    actions:{
        processUserToken({commit},value){
            var splitToken = JSON.parse(value).split('.')
            var userInfo = window.atob(splitToken[1]);
            commit("setUserName",JSON.parse(userInfo));
        },
        saveToken({commit},value){   
            localStorage.setItem('token', JSON.stringify(value));
            commit("setUserName",JSON.parse(value));
        },
        urlConfig({commit},value){
            commit("setConfig",value)
        }
    },
    getters: {
        getToken: (state) => state.sessionToken,
        getUser(state) {
            console.log("satte",state.sessionToken);
            return state.sessionToken;
        },
        getUrl:(state)=> state.apiUrl,
        getIsLogged:()=>{
            var token = localStorage.getItem('token');
            if(token) 
                return true;                
            
            return false;
        }

    }



})