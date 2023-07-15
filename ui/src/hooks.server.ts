import type { Handle } from "@sveltejs/kit";
import { SvelteKitAuth } from "@auth/sveltekit";
import Discord from "@auth/core/providers/discord";
import { AUTH_SECRET, DISCORD_CLIENT_ID, DISCORD_CLIENT_SECRET } from '$env/static/private';
import { sequence } from "@sveltejs/kit/hooks";
import type { JWT } from "@auth/core/jwt";
import type { User } from "$lib/models/player";
import { getUserFromDiscordToken } from "$lib/server/AuthRepo";

const authorizationHandle: Handle = async({ event, resolve }) => {
    return resolve(event);
}
const sessionHandle: Handle = async ({ event, resolve }) => { 
    const session = await event.locals.getSession();
    if(session === null){
        return resolve(event);
    }
    //Check if this session has an identity built on our side
    if(session.expires){
    }
    if(session.user.isNewUser && !event.url.href.includes("/account/register")){
        
        return new Response(null, {
            status: 303, 
            headers: { 
                location: "/account/register" 
            }
        });
    }
    //if it does
        //check if it doesn't have a signed JWT
        // if it does
            //resolve
        // if it doesn't
            //request updated identity from API
    //if it doesnt
        //send to reg flow
    return resolve(event);
}

async function getUserFromDiscordAuth(token: JWT): Promise<User | null>{
    return await getUserFromDiscordToken(token);
}
export const handle: Handle = sequence(
    SvelteKitAuth({
        //@ts-expect-error issue https://github.com/nextauthjs/next-auth/issues/6174
        providers: [Discord({clientId: DISCORD_CLIENT_ID, clientSecret: DISCORD_CLIENT_SECRET})],
        secret: AUTH_SECRET,
        callbacks: {
            signIn(params){
                if(params.profile && "bot" in params.profile && params.profile.bot){
                    return false;
                }
                return true;
            },
            async jwt(params){
                let user: User | null = null;
                console.log("JWT Callback Params", params);
                if(params.account?.provider === "discord"){
                    user = await getUserFromDiscordAuth(params.token);
                }
                console.log(user);
                if(user == null){
                    params.token.isNewUser = true;
                    params.token.authProvider = params.token.authProvider ?? params.account?.provider;
                }
                console.log("Returning Token", params.token);
                return params.token;
            },
            async session({session, token, user}) {
                console.log("Session Params", session, token, user);
                session.user.authProvider = token.authProvider;
                session.user.isNewUser = token.isNewUser;
                return session;
            },
        },
    }), 
    sessionHandle,
    authorizationHandle,
);
