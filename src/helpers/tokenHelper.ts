export function getAccessToken() {
    return localStorage.getItem("ACCESS_TOKEN") ?? "";
}

export function saveAccessToken(value: string) {
    localStorage.setItem("ACCESS_TOKEN", value);
}

export function getRefreshToken() {
    return localStorage.getItem("REFRESH_TOKEN") ?? "";
}

export function saveRefreshToken(value: string) {
    localStorage.setItem("REFRESH_TOKEN", value);
}