import type { Player } from '$lib/models/player';
import type { PageLoad } from './$types';

export const load: PageLoad = async ({ params }) => {
	const result = {
		players: new Array<Player>()
	};
	return result;
};
