import React from 'react'
import {connect} from 'react-redux'
import '../css/chats.css'

const Chat = ({activeChat}) => {
    return (
        <div className='open-chat'>
            <header className='chat-header'><span>{activeChat}</span></header>
        </div>
    )
}

const mapStateToProps = (state) => ({
    activeChat: state.userReducer.activeChat
})

export default connect(mapStateToProps)(Chat);