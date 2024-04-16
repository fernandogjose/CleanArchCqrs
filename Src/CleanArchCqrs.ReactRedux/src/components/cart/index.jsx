import * as Styles from "./styles";
import { useSelector } from "react-redux";
import CartItem from "../cart-item/index"
import { selectProductsPriceTotal } from "../../redux/cart/selectors";

const Cart = ({ isVisible, setIsVisible }) => {
  const handleEscapeAreaClick = () => setIsVisible(false);
  const { products } = useSelector((rootReducer) => rootReducer.cartReducer);
  const productsPriceTotal = useSelector(selectProductsPriceTotal);

  return (
    <Styles.CartContainer isVisible={isVisible}>
      <Styles.CartEscapeArea onClick={handleEscapeAreaClick} />
      <Styles.CartContent>
        <Styles.CartTitle>Seu Carrinho</Styles.CartTitle>
        {products.map((product) => (
          <CartItem product={product} key={product.id}></CartItem>
        ))}

        <Styles.CartTotal>Total: R${productsPriceTotal},00</Styles.CartTotal>
      </Styles.CartContent>
    </Styles.CartContainer>
  );
};

export default Cart;
