import axios from "axios";
import { useUserStore } from '../store/UserStore'

// axios.defaults.headers.common.Accept = 'application/json';

export const useApi = () => {

    const user = useUserStore();
    const url = user.getUrl;

    const signIn = async()=>{
        const res = await  axios.get(url);
        res && user.sessionToken(res);
    }

    return {signIn}
}