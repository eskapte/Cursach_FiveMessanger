import {combineReducers} from 'redux';
import initialState from './initialState';

const userReducer = (state=initialState, action) => {
    switch (action.type) {
        case "USER_LOGIN":
            return {...state, currentUser: {token: action.token, username: action.username}};
        default:
            return state;
    }
}

const reducer = combineReducers({
    userReducer: userReducer
})

export default reducer;