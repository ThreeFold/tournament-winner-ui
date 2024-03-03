import { getCommunity } from '$lib/server/CommunityRepo';
import type { LayoutServerLoad } from './$types';

export const load = (async ({ params }) => {
    const community = await getCommunity(params.communityIdentifier);
    return {
        community: community,
        communityHref: `/community/${community?.slug ?? community?.id}`
    };
}) satisfies LayoutServerLoad;
