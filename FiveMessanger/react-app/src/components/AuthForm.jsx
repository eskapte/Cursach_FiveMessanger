import React, {useState, useRef} from 'react'
import '../css/auth-form.css'
import {connect} from 'react-redux'
import {Loader, Dimmer, Segment} from 'semantic-ui-react'
import {getToken} from '../api/api'
import {Redirect} from 'react-router-dom'
import {userLogin} from '../store/actionCreators'

const AuthForm = ({userLogin, ...currentUser}) => {

    const loginRef = useRef(null);
    const passwordRef = useRef(null);
    const [isLoad, setLoad] = useState(false);
    const [error, setError] = useState(null);

    const sendForm = async function(username, password)
    {
        if (username.trim() == '' || password.trim() == '') {
            setError("Введите логин и пароль");
            return ;
        }
        setLoad(true);
        setError('');
        loginRef.current.value = '';
        passwordRef.current.value = '';
        const response = await getToken(username, password);
        if (!response)
        {
            setError("Неправильный логин или пароль");
            setLoad(false);
            return ;
        }
        window.localStorage.setItem('token', response.access_token);
        window.localStorage.setItem('username', response.username);
        console.log(response);
        userLogin({username: response.username, token: response.access_token})
        window.location.href = '/messages/'
        setLoad(false);
        return ;
    }

    return (
        isLoad ? <Loader active size='big'>Загрузка...</Loader> : 
        <div className="auth-modal">
            <header className="authform-header">
                <h2>Авторизация</h2>
            </header>
            <form className="auth-form">
                <label>
                    <span>Логин:</span><br></br>
                    <input type="text" name="login" id="login" placeholder="Введите логин..." ref={loginRef}/>
                </label><br></br>
                <label>
                    <span>Пароль:</span><br></br>
                    <input type="password" name='password' id='password' placeholder="Введите пароль..." ref={passwordRef}/>
                </label>
                <span className='errors'>{error}</span>
                <input type="button" value='Войти' onClick={() => sendForm(loginRef.current.value, passwordRef.current.value)}/>
            </form>
        </div>
    )
}

const mapStateToProps = (state) => ({
    currentUser: state.userReducer.currentUser
})

const mapDispatchToProps = {
    userLogin
}

export default connect(null, mapDispatchToProps)(AuthForm);