import type { Character } from '$lib/models/player';
import type Player from '$lib/models/player';
import type { PageLoad } from './$types';

export const load: PageLoad = async ({ params }) => {
    try {
        return {
            players: []
        };
    } catch (e) {
        console.error(e);
    }
};
