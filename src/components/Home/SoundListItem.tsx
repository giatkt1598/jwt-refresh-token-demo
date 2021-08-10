import { List } from "antd";
import React from "react";
import likeIcon from "../../assets/icons/icons8_facebook_like_96px.png";
import { Sound } from "../../models/sound";

export function SoundListItem(props: { item: Sound }) {
    return (
        <List.Item>
            <div
                className="horizontal-center sound-item"
                style={{ padding: '8 16' }}>
                <div style={{
                    cursor: 'pointer'
                }}>
                    <span style={{
                        marginRight: 8,
                        fontWeight: "bold",
                        fontSize: '1.4em'
                    }}>
                        {props.item.liked}
                    </span>
                    <img src={likeIcon}
                        width="32"
                        height="32" />

                </div>
                <div>
                    <div className="sound-title">
                        {props.item.title}
                    </div>
                    <div className="sound-author">
                        {props.item.author}
                    </div>
                </div>
            </div>
            <div>
                <video controls
                    style={{ height: 30, width: 500 }}
                >
                    <source src={props.item.soundUrl}
                        type="audio/mp3" />
                </video>
            </div>
        </List.Item>
    );
}