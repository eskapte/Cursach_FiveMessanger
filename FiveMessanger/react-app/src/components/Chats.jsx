import React from 'react'
import '../css/chats.css'
import {connect} from 'react-redux'
import {
    Router,
    Switch,
    Route,
    Link
  } from "react-router-dom";
import history from '../history';

const Chats = (chats) => {

    function selectChat(evt) {
        evt.preventDefault();
        window.location.pathname = '/messages/' + evt.currentTarget.getAttribute('href')
    }

    return (
        <div className='chats'>
            {chats.chats.map(chat => (
                    <a href={`${chat.chatName}`} className='chat' onClick={selectChat}>
                        <h3>{chat.chatName}</h3>
                    </a>
                ))}
        </div>
    )
}

const mapStateToProps = (state) => ({
    chats: state.userReducer.chats
})

export default connect(mapStateToProps)(Chats);