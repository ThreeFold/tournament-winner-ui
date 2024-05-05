import type { CommunityGame } from '$lib/models/player';
import { getCommunityGames } from '$lib/server/CommunityRepo';
import type { PageServerLoad } from './$types';

export const load = (async ({ params }) => {
	const communityGames = await getCommunityGames(params.communityIdentifier);
	return {
		communityGames: communityGames ?? new Array<CommunityGame>()
	};
}) satisfies PageServerLoad;
