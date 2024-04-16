import CartActionTypes from "./action-types"

export const cartProductAdd = (payload) => ({
    type: CartActionTypes.PRODUCT_ADD,
    payload: payload
});

export const cartProductRemoveAll = (payload) => ({
    type: CartActionTypes.PRODUCT_REMOVE_ALL,
    payload: payload
});

export const cartProductDecrease = (payload) => ({
    type: CartActionTypes.PRODUCT_DECREASE,
    payload: payload
});

export const cartProductIncrease = (payload) => ({
    type: CartActionTypes.PRODUCT_INCREASE,
    payload: payload
});