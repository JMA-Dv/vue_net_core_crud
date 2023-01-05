import { notify } from "@kyvg/vue3-notification";
import axios from "axios";
import store from "../store/store";
import ErrorService from "./ErrorService";


export const useProductApi = () => {
    const url = store.getters.getUrl + 'api/product';
    const getAll = async (page, take) => {
        try {

            const res = await axios.get(url + `?page=${page}&take=${take}`);
            return res.data;

        } catch (error) {
            ErrorService.onError(error)
        }
    }

    const edit = async (id, product) => {
        try {
            const res = await axios.put(url + `/${id}`, product)
            if (res.data.status === 200) {
                notify({
                    title: "Updated successfully",
                    text: "Product updates successfully"
                })
            }
            return res
        } catch (error) {
            ErrorService.onError(error)
        }
    }

    const deleteProduct = async (id) => {
        try {
            const res = await axios.delete(url + `/${id}`);
            if (res.data.status === 200) {
                notify({
                    type: 'Success',
                    title: "Deleted successfully",
                })
            }
            return res;

        } catch (error) {
            ErrorService.onError(error)
        }
    }
    const getById = async (id) => {
        try {
            const res = await axios.get(url + `api/product/${id}`);
            return res.data;
        } catch (error) {
            ErrorService.onError(error);
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


    return { getAll, create, edit, getById, deleteProduct }

}