import axios from "axios";
import store from "../store/store";
import ErrorService from "./ErrorService";


export const useProductApi = () => {
    const url = store.getters.getUrl;
    const getAll = async (page, take) => {
        try {

            const res = await axios.get(url + `api/product?page=${page}&take=${take}`);
            return res.data.items;

        } catch (error) {
            ErrorService.onError(error)
        }
    }
    const create = async (product) => {
        try {
            const res = await axios.post(url + `api/product`, product)
            return res;
        } catch (error) {
            ErrorService.onError(error)
        }
    }


    return { getAll, create }

}