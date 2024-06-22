import { env } from '$env/dynamic/private';
import type Community from '$lib/models/repo/Community';
import type { PageServerLoad } from './$types';

export const load = (async ({fetch}) => {
    const url = new URL(`community`, env.APP_API_BASE);
    const response = await fetch(url);
    if(!response.ok) {
        console.error("API did not respond successfully", response, await response.text())
        return {};
    }
    const result = (await response.json()) as Array<Community>;
    return {
        communities: result, 
    };
}) satisfies PageServerLoad;
