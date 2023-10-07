import type { User } from '$lib/models/player';
import type { PageServerLoad } from './$types';

export const load = (async ({params}) => {

    //grab all user details
    const user: User = {
        id: '',
        email: ''
    };
    return {};
}) satisfies PageServerLoad;