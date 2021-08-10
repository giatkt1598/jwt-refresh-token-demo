import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { PagingInfo } from "../models/pagingInfo";
import { Sound } from "../models/sound";

export interface SoundState {
    sounds: Array<Sound>,
    pagingInfo: PagingInfo,
};

const initialState: SoundState = {
    sounds: [],
    pagingInfo: {
        page: 0,
        size: 0,
        total: 0,
    },
};

const soundSlice = createSlice({
    name: "soundSlice",
    initialState,
    reducers: {
        setSound: (s: SoundState, action: PayloadAction<Sound[]>) => {
            s.sounds = action.payload;
        },
        setPagingInfo: (s: SoundState, action: PayloadAction<PagingInfo>) => {
            s.pagingInfo = action.payload;
        }
    }
});

export default soundSlice;

export const { setSound, setPagingInfo } = soundSlice.actions;