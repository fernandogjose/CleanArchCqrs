import { BsCartPlus } from "react-icons/bs";
import { useDispatch } from "react-redux";
import CustomButton from "../custom-button/index";
import * as Styles from "./styles";
import { cartProductAdd } from "../../redux/cart/slice";

const ProductItem = ({ product }) => {
    const dispacth = useDispatch();
    const handleProductClick = () => {
        dispacth(cartProductAdd(product));
    };

    return (
        <Styles.ProductContainer>
            <Styles.ProductImage imageUrl={product.imageUrl}>
                <CustomButton
                    startIcon={<BsCartPlus />}
                    onClick={handleProductClick}
                >
                    Adicionar ao carrinho
                </CustomButton>
            </Styles.ProductImage>

            <Styles.ProductInfo>
                <p>{product.name}</p>
                <p>R${product.price}</p>
            </Styles.ProductInfo>
        </Styles.ProductContainer>
    );
};

export default ProductItem;
