import { env } from '$env/dynamic/private';
import type { PageServerLoad } from './$types';

enum CommunityUserRole {
    Owner = 1,
    Administrator = 2,
    Moderator = 3,
    Manager = 4,
    Member = 5
}
const modRoles = [
    CommunityUserRole.Owner,
    CommunityUserRole.Administrator,
    CommunityUserRole.Moderator,
    CommunityUserRole.Manager
];
export const load = (async ({ locals, params, fetch }) => {
    const user = await locals.auth();
    const communityIdentifier = params.communityIdentifier;
    const fetchUrl = new URL(`community/${communityIdentifier}/users`, env.APP_API_BASE);
    for (const modRole of modRoles) {
        fetchUrl.searchParams.append('type', modRole.toString());
    }
    console.log(fetchUrl);
}) satisfies PageServerLoad;
