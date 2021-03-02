const initialState = {
    currentUser: {
        token: window.localStorage.getItem("token"),
        username: window.localStorage.getItem("username")
    },
    chats: [
        {
            id: 1,
            chatName: 'first',
            icon: null,
            participants: ['eskapte', 'anna', 'lhawick']
        }
    ],
    activeChat: 'first',
}

export default initialState;