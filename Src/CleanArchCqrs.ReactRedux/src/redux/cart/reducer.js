import CartActionTypes from "./action-types"

const initialState = {
    products: [],
    productsPriceTotal: 0
};

const cartReducer = (state = initialState, action) => {
    switch (action.type) {
        case CartActionTypes.PRODUCT_ADD:
            const productIsAlreadyInCart = state.products.some(
                (product) => product.id == action.payload.id
            );

            if (productIsAlreadyInCart) {
                return {
                    ...state,
                    products: state.products.map(
                        (product) => product.id == action.payload.id
                            ? { ...product, quantity: product.quantity + 1 }
                            : product
                    )
                };
            }

            return {
                ...state,
                products: [...state.products, { ...action.payload, quantity: 1 }]
            };

        case CartActionTypes.PRODUCT_REMOVE:
            return {
                ...state,
                products: state.products.filter(
                    (product) => product.id != action.payload
                )
            };

        default:
            return state;
    }
};

export default cartReducer;