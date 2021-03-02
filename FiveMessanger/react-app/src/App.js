import Template from './components/Template'
import AuthForm from './components/AuthForm'
import {Router, Route, Switch, Redirect} from 'react-router-dom'
import {connect} from 'react-redux'
import Chats from './components/Chats'
import React from 'react';
import Chat from './components/Chat'
import history from './history';

function App({currentUser, activeChat}) {

  if (!currentUser.token)
  {
    if (window.location.pathname != '/auth')
      window.location.pathname = '/auth';
    return <AuthForm/>
  }
  else
    return (
      <React.Fragment>
      <Template/>
        <Router history={history}>
              <Route path="/messages/" component={Chats}></Route>
              <Route exact path={`/messages/${activeChat}`} component={Chat}></Route>
              <Route exact path='/auth' render={() => {
                !currentUser.token ? <AuthForm/> : <Redirect to='/messages/'/> 
              }}></Route>
          </Router>
      </React.Fragment>
  );
}

const mapStateToProps = (state) => ({
  currentUser: state.userReducer.currentUser,
  activeChat: state.userReducer.activeChat
})

export default connect(mapStateToProps)(App);
