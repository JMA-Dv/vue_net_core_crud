import {defineStore} from 'pinia'

export const useUserStore = defineStore('UserStore',{
    state:()=>({
        sessionToken: '',
        userName:'DefaultUser',
        apiUrl:''
    }),
    getters:{
        getUser:(state)=> state.userName
    },
    actions:{
        setUserName(user){
            this.userName = user;
        },
        setConfig(configUrl){
            this.apiUrl = configUrl;
        }
    }
})