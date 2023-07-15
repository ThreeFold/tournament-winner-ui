import type Community from "$lib/models/community";
import { PUBLIC_APP_API_BASE } from '$env/static/public';
import type { CommunityGame } from "$lib/models/player";

export async function getCommunityList(): Promise<Array<Community>>{
        try {
            const response = await fetch(`${PUBLIC_APP_API_BASE}/community/list`);
            const communities = await response.json() as Array<Community>;
            return communities;
        } catch (e){
            console.log(e);
        }
        return new Array<Community>();
}

export async function getCommunity(id: string|number): Promise<Community | null> {
    try {
        const response = await fetch(`${PUBLIC_APP_API_BASE}/community/${id}`);
        const community = await response.json() as Community;
        return community
    } catch(e){
        console.error(e);
    }
    return null;
}

export async function getCommunityGames(id: string|number): Promise<Array<CommunityGame>>{

    try{
        const response = await fetch(`${PUBLIC_APP_API_BASE}/community/${id}/games`);
        const communityGames = await response.json() as Array<CommunityGame>;
        return communityGames;
    } catch(e){
        console.error(e);
    }
    return new Array<CommunityGame>();
}