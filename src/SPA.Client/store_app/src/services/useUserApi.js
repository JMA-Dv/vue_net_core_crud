import store from "../store/store"
import ErrorService from "./ErrorService";
import axios from "axios";

export const useUserApi = () => {

    const url = store.getters.getUrl;

    const getAll = async (page, take) => {
        try {
            return await axios.get(url + `api/user?page=${page}&take=${take}`);
        } catch (error) {
            ErrorService.onError(error)
        }
    }

    return { getAll }
}