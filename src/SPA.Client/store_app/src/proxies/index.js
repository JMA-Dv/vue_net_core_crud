/* eslint-disable */
// import SignInProxy from "./SignInProxy"
import axios, { Axios } from "axios";

//TODO: implement auth services 
export default {
    // signIn: new SignInProxy(),

    install: (app, options) => {
        const signIn = () =>{
        }
        app.provide('proxies', signIn);

    }

}