import { env } from '$env/dynamic/public';
import type Community from '$lib/models/repo/Community';
import { get } from '$lib/server/API';
import type { LayoutServerLoad } from './$types';

export const load = (async ({ params }) => {
    const fetchUrl = new URL(`/community/${params.communityIdentifier}`, env.PUBLIC_APP_API_BASE);
    const community = await get<Community>(fetchUrl);
    return {
        community: community,
        communityHref: `/community/${community?.slug ?? community?.id}`
    };
}) satisfies LayoutServerLoad;
