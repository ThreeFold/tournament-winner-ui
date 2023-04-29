import type Community from "$lib/models/community";
import { APP_API_BASE } from '$env/static/private';
export default class CommunityRepo {
    public async getCommunityList(): Promise<Array<Community>>{
        try {
            const response = await fetch(`${APP_API_BASE}/community/fetch`);
            const communities = await response.json() as Array<Community>;
            return communities;
        } catch (e){
            console.log(e);
        }
        return new Array<Community>();
    }
}