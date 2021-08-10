import axios from "axios";
import { PagingInfo } from "../models/pagingInfo";
import { Sound } from "../models/sound";

export async function getSounds(page: number, size: number)
    : Promise<{pagingInfo: PagingInfo, data: Array<Sound>}> {
        let result = {
            pagingInfo: {
            page: 0,
            size: 0,
            total: 0,
        }, data: new Array<Sound>(),
        };
        const response = await axios.get("sounds", {
            params: {
                "page": page,
                "size": size,
            },
        });
         result.pagingInfo = response.data as PagingInfo;
         result.data = response.data.data;
        return result;
    }