import { notify } from "@kyvg/vue3-notification";
import axios from "axios";
import { useUserStore } from '../store/UserStore'
import ErrorService from "./ErrorService";

axios.defaults.headers.common.Accept = 'application/json';

export const useApi = () => {
    const userStore = useUserStore();
    const url = userStore.getUrl

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
                userStore.setUserToken(res.data);
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