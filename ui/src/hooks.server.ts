import type { Handle, HandleFetch, HandleServerError } from "@sveltejs/kit";
import { SvelteKitAuth } from "@auth/sveltekit";
import Discord from "@auth/core/providers/discord";
import Auth0 from "@auth/core/providers/auth0";
import type {Provider} from '@auth/core/providers';
import type {Profile} from '@auth/core/types';
import { AUTH_SECRET, DISCORD_CLIENT_ID, DISCORD_CLIENT_SECRET, AUTH0_CLIENT_ID, AUTH0_CLIENT_SECRET } from '$env/static/private';

export const handle = SvelteKitAuth({
    providers: [
        Auth0({
            clientId: AUTH0_CLIENT_ID, 
            clientSecret: AUTH0_CLIENT_SECRET,
            issuer: 'dev-80ja08wntnvjbfkt.us.auth0.com'
            }) as Provider<Profile>,
                Discord({clientId: DISCORD_CLIENT_ID, clientSecret: DISCORD_CLIENT_SECRET}) as Provider<Profile>],
    secret: AUTH_SECRET
});