import UserActionTypes from "./action-types"

export const userLogin = (payload) => ({
    type: UserActionTypes.LOGIN,
    payload: payload
});

export const userLogout = () => ({
    type: UserActionTypes.LOGOUT
});