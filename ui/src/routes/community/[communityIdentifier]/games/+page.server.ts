import { env } from '$env/dynamic/private';
import type { CommunityGame } from '$lib/models/player';
import { get } from '$lib/server/API';
import type { PageServerLoad } from './$types';

export const load = (async ({ params }) => {
    const fetchUrl = new URL(`community/${params.communityIdentifier}/games`, env.APP_API_BASE);
    const games = await get<Array<CommunityGame>>(fetchUrl);
    console.log(games);
    return {
        communityGames: games
    };
}) satisfies PageServerLoad;
