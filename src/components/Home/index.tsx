import React from "react";
import "../../styles/home.css"
import { useAppDispatch, useAppSelector } from "../../store/hooks";
import { useEffect } from "react";
import { getSounds } from "../../store/actions/action.sound";
import { logout as logoutAction } from "../../store/actions/action.authentication";
import { HomeHeader } from "./HomeHeader";
import { SoundList } from "./SoundList";
import { Pagination } from "antd";
import { getUserInfo } from "../../store/actions/action.user";

function Home() {
    const dispatch = useAppDispatch();
    const user = useAppSelector(s => s.user.user);
    const logout = () => {
        dispatch(logoutAction());
    }
    const sounds = useAppSelector(s => s.sound.sounds);
    const pagingInfo = useAppSelector(s => s.sound.pagingInfo);
    useEffect(() => {
        dispatch(getSounds(1, 2));
        dispatch(getUserInfo());
    }, []);
    return (
        <div>
            <HomeHeader signOutFn={logout} title={user.firstName} />
            <div
                style={{
                    width: '80%',
                    margin: 'auto',
                    padding: 16,
                }}>
                <SoundList sounds={sounds} />
                <Pagination
                    style={{ textAlign: "center", marginTop: 8 }}
                    total={pagingInfo.total}
                    defaultPageSize={2}
                    onChange={(page) => dispatch(getSounds(page, pagingInfo.size))}
                />
            </div>
        </div>
    );
}

export default Home;