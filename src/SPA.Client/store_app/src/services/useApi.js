import { notify } from "@kyvg/vue3-notification";
import axios from "axios";
import ErrorService from "./ErrorService";
import store from '../store/store'
axios.defaults.headers.common.Accept = 'application/json';

export const useApi = () => {
    
    const url = store.getters.getUrl

    const signUp = async (params) => {
        const fullUrl = url + 'api/user/signUp';
        try {
            const res = await axios.post(fullUrl, params);
            console.log("🚀 ~ file: useApi.js ~ line 17 ~ signUp ~ res", res)
            notify({
                title: "Created successfully",
                text: "User created successfully"
            })
        } catch (error) {
            ErrorService.onError(error);
        }
    }

    const logIn = async ({ email, password }) => {
        try {
            const res = await axios.post(url + 'api/user/login', { email, password });
            if (res) {
                store.dispatch("processToken",res.data);
                store.commit("setIsLogged",true);
                notify("Welcome");
                return true;
            }
            return false;
        } catch (error) {
            ErrorService.onError(error);
        }
    }

    return { signUp, logIn }
}