import axios from 'axios';
import API from './defaultApi';

export const getToken = async function getToken(username, password) {
    let response = null;
    response = await API.post("/get_token", {
        'username': username,
        'password': password
    }).then(resp => {
        return resp.data;
    }).catch(err => {
        console.error(err);
    })
    return response;
}