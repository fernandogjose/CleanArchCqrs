import { AiOutlinePlus, AiOutlineMinus, AiOutlineClose } from "react-icons/ai";
import * as Styles from "./styles";
import { useDispatch } from "react-redux";
import { cartProductRemoveAll, cartProductDecrease, cartProductIncrease } from "../../redux/cart/actions";

const CartItem = ({ product }) => {
  const dispach = useDispatch();

  const handleRemoveClick = () => {
    dispach(cartProductRemoveAll(product.id));
  };

  const handleIncreaseClick = () => { 
    dispach(cartProductIncrease(product.id));
  };

  const handleDecreaseClick = () => { 
    dispach(cartProductDecrease(product.id));
  };

  return (
    <Styles.CartItemContainer>
      <Styles.CartItemImage imageUrl={product.imageUrl} />

      <Styles.CartItemInfo>
        <p>{product.name}</p>
        <p>R${product.price},00</p>

        <Styles.CartItemQuantity>
          <AiOutlineMinus
            size={20}
            onClick={handleDecreaseClick}
            aria-label={`Decrease quantity of ${product.name}`}
          />
          <p>{product.quantity}</p>
          <AiOutlinePlus
            size={20}
            onClick={handleIncreaseClick}
            aria-label={`Increase quantity of ${product.name}`}
          />
        </Styles.CartItemQuantity>
      </Styles.CartItemInfo>

      <Styles.RemoveButton
        onClick={handleRemoveClick}
        aria-label={`Remove ${product.name}`}
      >
        <AiOutlineClose size={25} />
      </Styles.RemoveButton>
    </Styles.CartItemContainer>
  );
};

export default CartItem;
