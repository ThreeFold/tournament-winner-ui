export default class CommunityRepo {

    private apibase: string;
    constructor(apiUrl: string){
        this.apibase = apiUrl;
    }

    public getCommunityList(){
        fetch(`${this.apibase}/Community/List`,)
    }
}