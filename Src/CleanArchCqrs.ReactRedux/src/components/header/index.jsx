import { useState } from "react";
import { useSelector, useDispatch } from "react-redux";
import { userLogin, userLogout } from "../../redux/user/actions"
import { selectProductsCount } from "../../redux/cart/selectors";
import Cart from "../cart/index";
import * as Styles from "./styles";

function Header() {
  const [cartIsVisible, setCartIsVisible] = useState(false);
  const { currentUser } = useSelector((rootReducer) => rootReducer.userReducer);
  const productsCount = useSelector(selectProductsCount);
  const dispatch = useDispatch();

  const handleCartClick = () => {
    setCartIsVisible(true);
  };

  const handleLoginClick = () => {
    dispatch(userLogin({
      name: "Fernando",
      email: "fernandogjose@gmail.com"
    }))
  };

  const handleLogoutClick = () => {
    dispatch(userLogout())
  };

  return (
    <Styles.Container>
      <Styles.Logo>Redux Shopping</Styles.Logo>
      <Styles.Buttons>
        {currentUser
          ? (<div onClick={handleLogoutClick}>Sair</div>)
          : (<div onClick={handleLoginClick}>Login</div>)
        }
        <div onClick={handleCartClick}>Carrinho ({productsCount})</div>
      </Styles.Buttons>

      <Cart isVisible={cartIsVisible} setIsVisible={setCartIsVisible} />
    </Styles.Container>
  );
}

export default Header;
