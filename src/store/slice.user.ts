import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { User } from "../models/user";

export interface UserState {
    user: User,
};

const initialState: UserState = {
    user: {
        id: 0,
        firstName: "",
        lastName: "",
        username: "",
    },
};

const userSlice = createSlice({
    name: "userSlice",
    initialState,
    reducers: {
        setUser: (state, action: PayloadAction<{user: User}>) => {
            state.user = action.payload.user;
        },
    },
})

export default userSlice;

export const { setUser } = userSlice.actions;