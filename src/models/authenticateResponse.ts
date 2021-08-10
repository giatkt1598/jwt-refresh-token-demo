export class AuthenticateResponse {
    accessToken: string;
    refreshToken: string;
    firstName: string;
    lastName: string;

    /**
     *
     */
    constructor(accessToken: string, refreshToken: string, firstName: string, lastName: string) {
        this.accessToken = accessToken;
        this.refreshToken = refreshToken;
        this.firstName = firstName;
        this.lastName = lastName;
    }
}