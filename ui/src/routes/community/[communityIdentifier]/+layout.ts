import type Community from '$lib/models/community';
import type { LayoutLoad } from './$types';

export const load: LayoutLoad = async ({params}) => {
    try {
        console.log(`Grabbing Community: `, params.communityIdentifier);
        //const community = await fetch(`http://localhost:5109/api/community/${params.communityIdentifier}`);
        const communityData: Community = {
            id: 1,
            insertDate: new Date(),
            name: "Gem State Smash",
            ownerUserId: "1",
            slug: "gss",
            description: "South Idaho's primary community"
        };

        return {
            community: communityData,
            communityHref: `/community/${communityData.slug}`
        };
    } catch(e){ 
        console.log(e);
    }
};