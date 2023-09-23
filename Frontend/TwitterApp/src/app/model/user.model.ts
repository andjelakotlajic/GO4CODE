export class User {
    private _username: string | null = null;
   
    constructor(private _token: string, private _expiration:string){}

    get token() {
        return this._token;
    }
    set (_username: string | null){
        this._username = _username;
    }
    get username(){
        return this._username;
    }

}