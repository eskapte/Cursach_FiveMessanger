import React from 'react'

const AuthForm = () => {
    return (
        <div className="auth-modal">
            <header className="authform-header">
                <h2>Авторизация</h2>
            </header>
            <form className="auth-form">
                <label>
                    <span>Логин:</span><br></br>
                    <input type="text" name="login" id="login" placeholder="Введите логин..."/>
                </label><br></br>
                <label>
                    <span>Пароль:</span><br></br>
                    <input type="password" name='password' id='password' placeholder="Введите пароль..."/>
                </label>
                <input type="button" value='Войти'/>
            </form>
        </div>
    )
}

export default AuthForm;