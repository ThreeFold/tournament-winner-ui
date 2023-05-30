import type { Handle, HandleFetch, HandleServerError } from "@sveltejs/kit";
import { SvelteKitAuth } from "@auth/sveltekit";
import Discord from "@auth/core/providers/discord";
import type {Provider} from '@auth/core/providers';
import type {Profile} from '@auth/core/types';
import { AUTH_SECRET, DISCORD_CLIENT_ID, DISCORD_CLIENT_SECRET } from '$env/static/private';

export const handle = SvelteKitAuth({
    providers: [Discord({clientId: DISCORD_CLIENT_ID, clientSecret: DISCORD_CLIENT_SECRET}) as Provider<Profile>],
    secret: AUTH_SECRET
});