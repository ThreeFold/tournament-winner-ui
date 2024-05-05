import type Region from '$lib/models/repo/Region';
import type { PageLoad } from './$types';

export const load: PageLoad = async () => {
    //This needs to be grabbed from the DB on load
    const countries = [{ name: 'United States of America', slug: 'usa' }];
    //The plan for this is to pull it from the DB whenever we select a country
    const regions: Array<Region> = [
        {
            name: 'Idaho',
            slug: 'id'
        }
    ];
    return {
        countries,
        regions
    };
};
