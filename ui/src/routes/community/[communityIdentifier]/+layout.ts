import type Community from '$lib/models/community';
import type { LayoutLoad } from './$types';

export const load: LayoutLoad = async ({params}) => {
    try {
        console.log(`Grabbing Community: `, params.communityIdentifier);
        const community = await fetch(`http://localhost:5109/api/community/${params.communityIdentifier}`);
        const communityData: Community = await community.json();

        return {
            community: communityData
        };
    } catch(e){ 
        console.log(e);
    }
};