import { defineStore } from 'pinia'

export const useUserStore = defineStore('UserStore', {
    state: () => ({
        sessionToken: '',
        user: {
            firstName:null,
            lastName: null,
            role:null
        },
        apiUrl: '',

    }),
    getters: {
        getUser: () => {
            var token = localStorage.getItem('token');
            if(token){
                var splitToken  = JSON.parse(token).split('.')
                var userInfo = window.atob(splitToken[1]);
                return JSON.parse(userInfo);
            }            
            return null;
        } ,
        getUrl:(state)=> state.apiUrl,
        getSesstionToken:()=>{
            var token = localStorage.getItem('token');
            if(token){
                return token;
            }
            
            return undefined;
        },
        getIsLogged:()=>{
            var token = localStorage.getItem('token');
            
            if(token) 
                return true;                
            
            return false;
        }
    },
    actions: {
        setUserName(user) {
            this.userName = user;
        },
        setConfig(configUrl) {
            this.apiUrl = configUrl;
            localStorage.setItem('config',JSON.stringify(configUrl));
        },
        setUserToken(token) {
            this.sessionToken = token
            localStorage.setItem('token',JSON.stringify(token));
        },
    }
})