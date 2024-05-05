import type { User } from '$lib/models/player';
import type { PageServerLoad } from './$types';

export const load = (async ({ params }) => {
    const user = {} as User;
    return {
        user
    };
}) satisfies PageServerLoad;
