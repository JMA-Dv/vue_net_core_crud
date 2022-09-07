import axios from "axios";
import { useUserStore } from '../store/UserStore'

// axios.defaults.headers.common.Accept = 'application/json';

export const useApi = () => {
    

    const user = useUserStore();
    const url = "";

    const signIn = async(params)=>{
        const res = await axios.post(url+'/api/user',params);
        
        res && user.sessionToken(res);
    }

    

    return {signIn}
}