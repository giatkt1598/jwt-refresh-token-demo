export class PagingInfo {
    page: number;
    size: number;
    total: number;

    constructor(page: number, size: number, total: number) {
        this.page = page;
        this.size = size;
        this.total = total;
    }
}