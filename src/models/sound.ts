export class Sound {
    public id: number;
    public title: string;
    public author: string;
    public liked: number;
    public soundUrl: string;

    /**
     *
     */
    constructor(id: number, title: string, author: string, liked: number, soundUrl: string) {
        this.id = id;
        this.title = title;
        this.author = author;
        this.liked = liked;
        this.soundUrl = soundUrl;
    }

}