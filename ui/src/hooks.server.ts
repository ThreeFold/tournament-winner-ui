import type { Handle, HandleFetch, HandleServerError } from "@sveltejs/kit";
import { SvelteKitAuth } from "@auth/sveltekit";
import Discord from "@auth/core/providers/discord";
import type {Provider} from '@auth/core/providers';
import type {Profile} from '@auth/core/types';
import { AUTH_SECRET, DISCORD_CLIENT_ID, DISCORD_CLIENT_SECRET } from '$env/static/private';
import { sequence } from "@sveltejs/kit/hooks";

const authorizationHandle: Handle = async({ event, resolve }) => {
    return resolve(event);
}
const sessionHandle: Handle = async ({ event, resolve }) => {

    const session = await event.locals.getSession();
    if(session !== null){
        //Check if this session has an identity built on our side
        //if it does
            //check if it doesn't have a signed JWT
            // if it does
                //resolve
            // if it doesn't
                //request updated identity from API
        //if it doesnt
            //send to reg flow

    }
    return resolve(event);
}

export const handle: Handle = sequence(
    SvelteKitAuth({
        providers: [Discord({clientId: DISCORD_CLIENT_ID, clientSecret: DISCORD_CLIENT_SECRET}) as Provider<Profile>],
        secret: AUTH_SECRET
    }), 
    sessionHandle,
    authorizationHandle,
);
