import { PUBLIC_APP_API_BASE } from '$env/static/public';
import type { CommunityGame } from "$lib/models/player";
import type Community from '$lib/models/repo/community';

export async function getCommunityList(): Promise<Array<Community>>{
        try {
            const url = new URL(`community/list`, PUBLIC_APP_API_BASE);
            const response = await fetch(url);
            const communities = await response.json() as Array<Community>;
            return communities;
        } catch (e){
            console.error(e);
        }
        return new Array<Community>();
}

export async function getCommunity(id: string|number): Promise<Community | null> {
    try {        
        const url = new URL(`community/${id}`, PUBLIC_APP_API_BASE);
        const response = await fetch(url);
        console.log(response);
        const community = await response.json() as Community;
        return community
    } catch(e){
        console.error(e);
    }
    return null;
}

export async function getCommunityGames(id: string|number): Promise<Array<CommunityGame>>{

    try{
        const url = new URL(`community/${id}/games`, PUBLIC_APP_API_BASE);
        const response = await fetch(url);
        const communityGames = await response.json() as Array<CommunityGame>;
        return communityGames;
    } catch(e){
        console.error(e);
    }
    return new Array<CommunityGame>();
}
