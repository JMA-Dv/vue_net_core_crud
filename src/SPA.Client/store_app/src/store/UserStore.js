import {defineStore} from 'pinia'

export const useUserStore = defineStore('UserStore',{
    state:()=>({
        sessionToken: '',
        userName:'DefaultUser'
    }),
    getters:{
        getUser:(state)=> state.userName
    }
})