import {configureStore} from "@reduxjs/toolkit"
import authenticationSlice from "./slice.authentication"
import soundSlice from "./slice.sound";
import userSlice from "./slice.user";

export const store = configureStore({
    reducer: {
        authentication: authenticationSlice.reducer,
        user: userSlice.reducer,
        sound: soundSlice.reducer,
    },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;