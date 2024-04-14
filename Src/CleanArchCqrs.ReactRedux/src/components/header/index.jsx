import { useState } from "react";
import { useSelector, useDispatch } from "react-redux";
import Cart from "../cart/index";
import * as Styles from "./styles";
import { userLogin, userLogout } from "../../redux/user/actions"

function Header() {
  const [cartIsVisible, setCartIsVisible] = useState(false);
  const { currentUser } = useSelector((rootReducer) => rootReducer.userReducer);
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

  console.log({ currentUser });

  return (
    <Styles.Container>
      <Styles.Logo>Redux Shopping</Styles.Logo>
      <Styles.Buttons>
        {currentUser
          ? (<div onClick={handleLogoutClick}>Sair</div>)
          : (<div onClick={handleLoginClick}>Login</div>)
        }
        <div onClick={handleCartClick}>Carrinho</div>
      </Styles.Buttons>

      <Cart isVisible={cartIsVisible} setIsVisible={setCartIsVisible} />
    </Styles.Container>
  );
}

export default Header;
