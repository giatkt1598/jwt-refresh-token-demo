import axios from "axios";
import { sleep } from "../helpers/asyncHelper";
import { AuthenticateResponse } from "../models/authenticateResponse";
import { User } from "../models/user";

export async function login(username: string, password: string)
    : Promise<AuthenticateResponse | undefined> {
    await sleep();
    try {
        const response = await axios.post(`users/authenticate`,
        {
            username,
            password
        });
        const authModel: AuthenticateResponse = {
            accessToken: response.data.accessToken,
            refreshToken: response.data.refreshToken,
            firstName: response.data.user.firstName,
            lastName: response.data.user.lastName,
        };
        return authModel;
    } catch (error) {
        console.log(error);
    }
    return undefined;
}

export async function refreshToken(refreshToken: string): Promise<AuthenticateResponse | undefined> {
    try {
        const response = await axios.post("users/refresh-token",
        {
            "token": refreshToken,
        });
        const authModel: AuthenticateResponse = {
            accessToken: response.data.accessToken,
            refreshToken: response.data.refreshToken,
            firstName: response.data.user.firstName,
            lastName: response.data.user.lastName,
        };

        return authModel;
    } catch (error) {
        console.log("refresh token failed: " + error);
    }
    return undefined;
}

export async function revokeToken(refreshToken: string): Promise<boolean> {
    console.log("revoke run");
    try {
        const response = await axios.post("users/revoke-token",
        {
            "token": refreshToken,
        });
        return response.status == 200;
    } catch (error) {
        console.log(error.response);
    }
    return false;
}

export async function getProfile(): Promise<User | undefined> {
    try {
        const response = await axios.get("users/profiles");
        const result = response.data as User;
        return result;
    } catch (err) {
        console.log(err);
    }
    return undefined;
}

