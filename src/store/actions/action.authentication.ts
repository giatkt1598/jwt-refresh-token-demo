import authenticationSlice from "../slice.authentication";
import {login as loginUser, refreshToken as refreshTokenUser, revokeToken} from "../../services/userService";
import {createBrowserHistory} from "history";
import { getRefreshToken, saveAccessToken, saveRefreshToken } from "../../helpers/tokenHelper";

const actions = authenticationSlice.actions;

export function login(username: string, password: string) {
    return (dispatch: Function) => {
        dispatch(actions.loginRequest());
        loginUser(username, password).then(authResponse => {
            if (authResponse) {
                saveAccessToken(authResponse.accessToken);
                saveRefreshToken(authResponse.refreshToken);
                dispatch(actions.loginSuccess());
            } else {
                dispatch(actions.loginFailed());
            }
        });
    }
}

export function logout() {
    return (dispatch: Function) => {
        revokeToken(getRefreshToken()).then((success) => {
            if (success) {
                dispatch(actions.logout());
                saveAccessToken("");
                saveRefreshToken("");
                createBrowserHistory().push("/login");
                window.location.reload();
            }
        })
    }
}
