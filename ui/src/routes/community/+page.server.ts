import { env } from '$env/dynamic/public';
import type Community from '$lib/models/repo/Community';
import { get } from '$lib/server/API';
import type { PageServerLoad } from './$types';


export const load = (async () => {
    const fetchUrl = new URL(`/community`, env.PUBLIC_APP_API_BASE);
    const communities = await get<Array<Community>>(fetchUrl);
    return {
        communities: communities
    };
}) satisfies PageServerLoad;
