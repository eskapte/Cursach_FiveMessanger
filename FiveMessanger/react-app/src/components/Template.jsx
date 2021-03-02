import React from 'react'
import '../css/template.css'
import {userLogin} from '../store/actionCreators'
import {connect} from 'react-redux'

const Template = (userLogin) => {

    function exit(evt) {
        window.localStorage.removeItem('token');
        window.localStorage.removeItem('username');
        userLogin({username: null, token: null});
        window.location.pathname = '/auth';
    }

    const username = window.localStorage.getItem('username');

    return (
        <React.Fragment>
            <header className='main-header'>
                <h1>Five</h1>
                <span>Добро пожаловать, {username}!</span>
                <a href="/auth" onClick={exit}>Выйти</a>
            </header>
            <nav className="main-nav">
                    <a href='/messages/' className='nav-link active-link'>Сообщения</a>
                    <a href='/marks' className='nav-link'>Оценки</a>
                    <a href='/homework' className='nav-link'>Домашнее задание</a>
                    <a href='/news' className='nav-link'>Новости</a>
                    <a href='/profile' className='nav-link'>Профиль</a>
            </nav>
        </React.Fragment>
    )
}

const mapDispatchToProps = {
    userLogin
}

export default connect(null, mapDispatchToProps)(Template)