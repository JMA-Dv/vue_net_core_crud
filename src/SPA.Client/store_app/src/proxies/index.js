/* eslint-disable */
// import SignInProxy from "./SignInProxy"
import axios, { Axios } from "axios";


export default {
    // signIn: new SignInProxy(),

    install: (app, options) => {
        const signIn = () =>{
            console.log("Logging out")
        }
        app.provide('proxies', signIn);

    }

}