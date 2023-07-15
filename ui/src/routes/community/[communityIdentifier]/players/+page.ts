import type Game from '$lib/models/Game';
import type { Character } from '$lib/models/player';
import type Player from '$lib/models/player';
import type { PageLoad } from './$types';

export const load: PageLoad = async ({params}) => {
    try{
        console.log("Grabbing players");
        return {
            
        };
    } catch (e) {
        console.log(e);
    }
};