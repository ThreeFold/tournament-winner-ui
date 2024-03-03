import { goto } from '$app/navigation';
import type Community from '$lib/models/repo/Community';
import { createCommunity } from '$lib/server/CommunityRepo';
import { redirect, type Actions } from '@sveltejs/kit';

export const actions: Actions = {
    default: async (event) => {
        const data = await event.request.formData();
        const session = await event.locals.getSession();
        if (!session) {
            // TODO: return fail when not signed in
            return;
        }
        const name = data.get('name') as string;
        const slug = data.get('slug') as string;
        const description = data.get('description') as string;
        const country = data.get('country') as string;
        const region = data.get('region') as string;
        const city = data.get('city') as string;
        const links = data.getAll('link') as Array<string>;

        const newCommunity: Community = {
            id: 0,
            ownerUserId: session.user.id,
            insertDate: new Date(),
            name,
            slug,
            description,
            country,
            regionState: region,
            city,
            links
        };
        const createdCommunity = await createCommunity(newCommunity);
        throw redirect(307, `/community/${createdCommunity.slug}`);
    }
};
