import { getCommunityList } from '$lib/server/CommunityRepo';
import type { PageServerLoad } from './$types';

export const load = (async () => {
    const communities = await getCommunityList();
    return {
        communities: communities
    };
}) satisfies PageServerLoad;
