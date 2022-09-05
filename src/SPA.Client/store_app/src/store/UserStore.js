import {defineStore} from 'pinia'

export const useUserStore = defineStore('UserStore',{
    state:()=>({
        sessionToken: 'tokenForTesting',
        userName:'DefaultUser',
        apiUrl:'url'
    }),
    getters:{
        getUser:(state)=> state.userName,
        getUrl:(state)=> state.apiUrl,
        getToken:(state)=> state.sessionToken,
    },
    actions:{
        setUserName(user){
            this.userName = user;
        },
        setConfig(configUrl){
            this.apiUrl = configUrl;
        },
        setUserToken(token) {
            this.sessionToken = token
        }
    }
})