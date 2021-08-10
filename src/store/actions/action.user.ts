import { getProfile } from "../../services/userService"
import { setUser } from "../slice.user"

export function getUserInfo() {
    return (dispatch: Function) => {
        getProfile().then(rs => {
            if (rs) {
                dispatch(setUser({user: rs}));
            }
        })

    }
}