import axios from 'axios';

export default axios.create({
    header: {
        'Access-Control-Allow-Origin': '*',
    },
    baseURL: 'http://localhost:5000/',
    responseType: 'json',
});