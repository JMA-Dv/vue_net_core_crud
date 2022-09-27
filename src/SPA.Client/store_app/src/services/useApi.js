import { notify } from "@kyvg/vue3-notification";
import axios from "axios";
import store from '../store/store';
import ErrorService from "./ErrorService";
axios.defaults.headers.common.Accept = 'application/json';
axios.interceptors.request.use(
    config => {
        let token = localStorage.getItem('token')
        if (token) {
            config.headers.Authorization = `Bearer ${JSON.parse(token)}`;
        }
        return config;
    },
    error => Promise.reject(error)
)


export const useApi = () => {

    const url = store.getters.getUrl


    const signUp = async (params) => {
        const fullUrl = url + 'api/auth/signUp';
        try {
            const res = await axios.post(fullUrl, params);
            if (res) {
                notify({
                    title: "Created successfully",
                    text: "User created successfully"
                })
            }
        } catch (error) {
            ErrorService.onError(error);
        }
    }

    const logIn = async ({ email, password }) => {
        try {
            const res = await axios.post(url + 'api/auth/login', { email, password });
            if (res) {
                store.dispatch("saveToken", res.data);
                store.commit("setIsLogged", true);

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