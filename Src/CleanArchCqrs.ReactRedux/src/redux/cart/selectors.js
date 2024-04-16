export const selectProductsCount = (rootReducer) => {
    return rootReducer.cartReducer.products.reduce(
        (acc, curr) => acc + curr.quantity,
        0
    );
}