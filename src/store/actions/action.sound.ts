import {getSounds as getSoundsAsync } from "../../services/soundService";
import soundSlice from "../slice.sound";

const actions = soundSlice.actions;

export function getSounds(page: number, size: number)  {
    return (dispatch: Function) => {
        getSoundsAsync(page, size).then(result => {
            dispatch(actions.setSound(result.data));
            dispatch(actions.setPagingInfo(result.pagingInfo));
        });
    };
}