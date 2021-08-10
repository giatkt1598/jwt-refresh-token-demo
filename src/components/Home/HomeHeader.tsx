import React from "react";
import radioIcon from "../../assets/icons/icons8_radio_128px.png";
import avatarIcon from "../../assets/icons/icons8_male_user_80px.png";
import shutdownIcon from "../../assets/icons/icons8_shutdown_96px.png";

export function HomeHeader(props: { title: string, signOutFn: Function }) {
    return (
        <div
            className="horizontal-center"
            style={{
                width: '100%',
                height: 50,
                display: "flex",
                background: "#2D2F90",
                color: 'white',
                padding: '0 8px'
            }}>
            <img src={radioIcon} alt="radio icon" width="32" height="32" />
            <h3 style={{ color: 'white', marginBottom: 0, marginLeft: 4 }}>ReactTracks</h3>
            <span style={{ flex: 1 }} />
            <img src={avatarIcon} alt="avatar icon" width="32" height="32" />
            <h3 style={{ color: 'white', marginBottom: 0, marginLeft: 4 }}>{props.title}</h3>
            <span style={{ flex: 1 }} />
            <h3 style={{ color: 'white', marginBottom: 0, marginRight: 4, cursor: "pointer" }}
                onClick={() => props.signOutFn()}>Sign out</h3>
            <img src={shutdownIcon} alt="logout icon" width="32" height="32" />
        </div>
    );
}