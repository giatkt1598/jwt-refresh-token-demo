import {createSlice, PayloadAction} from "@reduxjs/toolkit"

export enum LoginStatus {
    "LOGIN_REQUEST",
    "LOGIN_FAIL",
    "LOGIN_SUCCESS",
    "LOGIN_ERROR",
    "NONE",
}
interface AuthenticationState {
    accessToken: string,
    refreshToken: string,
    isAuthenticated: boolean,
    loginStatus: LoginStatus,
}

const initialState: AuthenticationState = {
    accessToken: "",
    refreshToken: "",
    isAuthenticated: false,
    loginStatus: LoginStatus.NONE,
}

const authenticationSlice = createSlice({
    name: "authenticationSlice",
    initialState,
    reducers: {
        loginRequest: s => {s.loginStatus = LoginStatus.LOGIN_REQUEST},
        loginSuccess: s => {s.loginStatus = LoginStatus.LOGIN_SUCCESS},
        loginFailed: s => {s.loginStatus = LoginStatus.LOGIN_FAIL},
        logout: s => {
            s.isAuthenticated = false;
            s.accessToken = "";
            s.refreshToken = "";
            s.loginStatus = LoginStatus.NONE;
        }
    }
})


export default authenticationSlice;