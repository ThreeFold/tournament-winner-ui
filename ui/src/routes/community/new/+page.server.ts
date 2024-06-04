import type CreateCommunityRequest from '$lib/models/api/Community';
import { error, redirect, type Actions } from '@sveltejs/kit';
import { env } from '$env/dynamic/private';
import type Community from '$lib/models/repo/Community';

export const actions: Actions = {
    default: async (event) => {
        const data = await event.request.formData();
        const session = await event.locals.auth();
        if (!session) {
            error(401, 'Could not grab your session from the request');
        }
        const name = data.get('name') as string;
        const slug = data.get('slug') as string;
        const description = data.get('description') as string;
        const country = data.get('country') as string;
        const region = data.get('region') as string;
        const city = data.get('city') as string;
        const links = data.getAll('link') as Array<string>;
        const ownerId = session.user.id!;

        const newCommunity: CreateCommunityRequest = {
            name,
            slug,
            description,
            country,
            regionState: region,
            city,
            ownerId,
            links
        };
        const url = new URL(`community`, env.APP_API_BASE);
        console.log(url);
        const response = await fetch(url, {
            method: 'POST',
            body: JSON.stringify(newCommunity),
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (!response.ok) console.log(await response.text());
        const createdCommunity = (await response.json()) as Community;
        redirect(307, `/community/${createdCommunity.slug}`);
    }
};
