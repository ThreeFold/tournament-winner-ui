import { redirect, type Handle } from "@sveltejs/kit";
import { SvelteKitAuth } from "@auth/sveltekit";
import Discord from "@auth/core/providers/discord";
import { AUTH_SECRET, DISCORD_CLIENT_ID, DISCORD_CLIENT_SECRET } from '$env/static/private';
import { sequence } from "@sveltejs/kit/hooks";
import type { User } from "$lib/models/player";
import { getUserFromDiscordToken } from "$lib/server/UserRepo";
import { registerUser } from "$lib/server/UserRepo";
import { UserCreateViewModel } from "$lib/server/UserRepo";
import { AuthMethod } from "$lib/enum/AuthMethod";

const authorizationHandle: Handle = async({ event, resolve }) => {
    return resolve(event);
}
const sessionHandle: Handle = async ({ event, resolve }) => { 
    const session = await event.locals.getSession();

    if(session?.user.isNewUser){
        redirect(307, "/account/new")
    }
    return resolve(event);
}

async function getUserFromDiscordAuth(discordId: string, email: string): Promise<User | null>{
    return await getUserFromDiscordToken(discordId, email);
}
export const handle: Handle = sequence(
    SvelteKitAuth({
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
                if(params.account?.provider === "discord"){
                    user = await getUserFromDiscordAuth(params.account.providerAccountId, params.profile?.email ?? "");
                    if(user == null){
                        params.token.isNewUser = true;
                        params.token.authProvider = params.token.authProvider ?? params.account?.provider;
                        const authMethod = AuthMethod.Discord;
                        const userToCreate = new UserCreateViewModel(params.user.name!, params.token.email!, authMethod, params.account!.providerAccountId);
                        user = await registerUser(userToCreate);
                    }
                }
                return params.token;
            },
            async session({session, token, user}) {
                session.user.authProvider = token.authProvider;
                session.user.isNewUser = token.isNewUser;
                return session;
            },
        },
    }), 
    sessionHandle,
    authorizationHandle,
);
