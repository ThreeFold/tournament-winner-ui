import { env } from '$env/dynamic/public';
import type { CommunityGame } from '$lib/models/player';
import { get } from '$lib/server/API';
import type { PageServerLoad } from './$types';

export const load = (async ({ params }) => {
    const fetchUrl = new URL(`/community/${params.communityIdentifier}/games`, env.PUBLIC_APP_API_BASE);
    const games = await get<Array<CommunityGame>>(fetchUrl);
    return {
        communityGames: games
    };
}) satisfies PageServerLoad;
