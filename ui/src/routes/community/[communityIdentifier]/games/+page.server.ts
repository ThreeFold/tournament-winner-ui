import { getCommunityGames } from '$lib/server/CommunityRepo';
import type { PageServerLoad } from './$types';

export const load = (async ({params}) => {
    try{
        const communityGames = await getCommunityGames(params.communityIdentifier);
        return {
            communityGames: communityGames
        };
    } catch (e) {
        console.error(e);
    }
}) satisfies PageServerLoad;