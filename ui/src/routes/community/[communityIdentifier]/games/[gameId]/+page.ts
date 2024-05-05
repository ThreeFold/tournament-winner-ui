import type { PlayerGame } from '$lib/models/player';
import type Game from '$lib/models/repo/Game';

export const load = async () => {
	return {
		game: {} as Game,
		players: new Array<PlayerGame>()
	};
};
