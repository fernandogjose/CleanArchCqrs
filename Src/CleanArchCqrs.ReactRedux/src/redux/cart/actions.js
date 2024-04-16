import CartActionTypes from "./action-types"

export const cartProductAdd = (payload) => ({
    type: CartActionTypes.PRODUCT_ADD,
    payload: payload
});

export const cartProductRemove = (payload) => ({
    type: CartActionTypes.PRODUCT_REMOVE,
    payload: payload
});