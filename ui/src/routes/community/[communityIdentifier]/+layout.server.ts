import { env } from '$env/dynamic/private';
import type Community from '$lib/models/repo/Community';
import { get } from '$lib/server/API';
import { error } from '@sveltejs/kit';
import type { LayoutServerLoad } from './$types';

export const load = (async ({ params, fetch }) => {
    const url = new URL(`community/${params.communityIdentifier}`, env.APP_API_BASE);
    const response = await fetch(url);
    if(!response.ok)
        throw error(response.status, await response.text());
    const community = (await response.json()) as Community;
    console.log(community);
    return {
        community: community,
        communityHref: `/community/${community?.slug ?? community?.id}`
    };
}) satisfies LayoutServerLoad;
