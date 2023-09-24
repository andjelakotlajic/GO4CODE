export class Tweet {
    userName: string;
    content: string;
    numLikes:number;
    createdAt:Date;
    id:number;

    constructor(userName: string, content:string,numLikes:number,createdAt:Date,id:number) {
        this.userName = userName;
        this.content = content;
        this.numLikes=numLikes;
        this.createdAt=createdAt;
        this.id = id;
    }

}