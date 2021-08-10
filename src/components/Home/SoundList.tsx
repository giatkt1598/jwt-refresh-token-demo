import { List } from "antd";
import React from "react";
import { Sound } from "../../models/sound";
import { SoundListItem } from "./SoundListItem";

export function SoundList(props: { sounds: Sound[] }) {
    return (
        <List
            size="large"
            // header={<div>Header</div>}
            // footer={<div>Footer</div>}
            bordered
            dataSource={props.sounds}
            renderItem={item => <SoundListItem item={item} />}
        />
    );
}