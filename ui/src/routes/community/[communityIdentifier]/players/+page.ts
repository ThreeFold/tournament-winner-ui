import type Player from '$lib/models/player';
import type { PageLoad } from './$types';

export const load: PageLoad = async ({params}) => {
    try{
        const response = await fetch(`http://localhost:5109/api/community/${params.communityIdentifier}/players`);
        const players: Array<Player> = await response.json();

        return {
            players
        };
    } catch (e) {
        console.log(e);
    }
};