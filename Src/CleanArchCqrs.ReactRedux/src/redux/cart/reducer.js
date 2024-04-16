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

        case CartActionTypes.PRODUCT_REMOVE_ALL:
            return {
                ...state,
                products: state.products.filter(
                    (product) => product.id != action.payload
                )
            };


        case CartActionTypes.PRODUCT_DECREASE:
            return {
                ...state,
                products: state.products.map(
                    (product) => product.id == action.payload
                        ? { ...product, quantity: product.quantity - 1 }
                        : product
                ).filter((product) => product.quantity > 0)
            };

        case CartActionTypes.PRODUCT_INCREASE:
            return {
                ...state,
                products: state.products.map(
                    (product) => product.id == action.payload
                        ? { ...product, quantity: product.quantity + 1 }
                        : product
                )
            };

        default:
            return state;
    }
};

export default cartReducer;