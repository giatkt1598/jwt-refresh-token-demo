import React from 'react'
import ReactDOM from 'react-dom'
import './styles/index.css'
import './styles/global.css'
import "antd/dist/antd.css"
import Login from './components/Login'
import Home from './components/Home'
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import { Provider } from 'react-redux'
import { store } from "./store"
import axios from "axios"
import { axiosSetup } from './setup/axiosSetup'

axiosSetup(axios);

ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <BrowserRouter>
        <Switch>
          <Route exact={true} path="/">
            <Home />
          </Route>
          <Route exact={true} path="/login">
            <Login />
          </Route>
        </Switch>
      </BrowserRouter>
    </Provider>
  </React.StrictMode>,
  document.getElementById('root')
)
