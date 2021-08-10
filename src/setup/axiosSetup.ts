import { toCamelCase } from "../helpers/toCamelCase";
import { getAccessToken, getRefreshToken, saveAccessToken, saveRefreshToken } from "../helpers/tokenHelper";
import { refreshToken } from "../services/userService";
import { createBrowserHistory } from "history";
import axios, { AxiosStatic } from "axios";
import { BaseURL } from "../services/config";

export function axiosSetup(axiosInstance: AxiosStatic) {
    axios.defaults.baseURL = BaseURL;

    axiosInstance.interceptors.request.use((config) => {
        config.headers["Authorization"] = `Bearer ${getAccessToken()}`
        return config;
    });
    axiosInstance.interceptors.response.use(response => {
    response.data = toCamelCase(response.data);
    return response;
    }, async (error) => {
    const httpStatus = error.response ? error.response.status : null;
    if (httpStatus == 401) {
        const rs = await refreshToken(getRefreshToken());
        if (rs) {
        error.config.headers["Authorization"] = `Bearer ${rs.accessToken}`;
        saveRefreshToken(rs.refreshToken);
        saveAccessToken(rs.accessToken);
        return axiosInstance.request(error.config);
        } else {
        createBrowserHistory().push("/login");
        window.location.reload();
        }
    };
    return Promise.reject(error);
    }
    );
}
