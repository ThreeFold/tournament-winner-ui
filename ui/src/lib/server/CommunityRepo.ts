import { PUBLIC_APP_API_BASE } from '$env/static/public';
import type { CommunityGame } from '$lib/models/player';
import type CreateCommunityRequest from '$lib/models/api/Community';
import type Community from '$lib/models/repo/Community';

export async function createCommunity(newCommunity: CreateCommunityRequest): Promise<Community> {
    const url = new URL(`community`, PUBLIC_APP_API_BASE);
    console.log(url);
    const response = await fetch(url, {
        method: 'POST',
        body: JSON.stringify(newCommunity),
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer {authToken}`
        }
    });
    console.log(response);
    const createdCommunity = (await response.json()) as Community;
    return createdCommunity;
}
export async function getCommunityList(): Promise<Array<Community>> {
    try {
        const url = new URL(`community/list`, PUBLIC_APP_API_BASE);
        const response = await fetch(url);
        const communities = (await response.json()) as Array<Community>;
        return communities;
    } catch (e) {
        console.error(e);
    }
    return new Array<Community>();
}

export async function getCommunity(id: string | number): Promise<Community | null> {
    try {
        const url = new URL(`community/${id}`, PUBLIC_APP_API_BASE);
        const response = await fetch(url);
        console.log(response);
        const community = (await response.json()) as Community;
        return community;
    } catch (e) {
        console.error(e);
    }
    return null;
}

export async function getCommunityGames(id: string | number): Promise<Array<CommunityGame>> {
    try {
        const url = new URL(`community/${id}/games`, PUBLIC_APP_API_BASE);
        const response = await fetch(url);
        const communityGames = (await response.json()) as Array<CommunityGame>;
        return communityGames;
    } catch (e) {
        console.error(e);
    }
    return new Array<CommunityGame>();
}
