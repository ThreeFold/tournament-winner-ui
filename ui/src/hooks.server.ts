import { redirect, type Handle } from '@sveltejs/kit';
import { SvelteKitAuth } from '@auth/sveltekit';
import Discord from '@auth/core/providers/discord';
import { AUTH_SECRET, DISCORD_CLIENT_ID, DISCORD_CLIENT_SECRET } from '$env/static/private';
import { sequence } from '@sveltejs/kit/hooks';
import type { User } from '$lib/models/player';
import { getUser, registerUser } from '$lib/server/UserRepo';
import { UserCreateViewModel } from '$lib/server/UserRepo';

const authorizationHandle: Handle = async ({ event, resolve }) => {
    return resolve(event);
};
const sessionHandle: Handle = async ({ event, resolve }) => {
    const session = await event.locals.getSession();

    if (session?.user.isNewUser) {
        redirect(307, '/account/new');
    }
    return resolve(event);
};

export const handle: Handle = sequence(
    SvelteKitAuth({
        providers: [Discord({ clientId: DISCORD_CLIENT_ID, clientSecret: DISCORD_CLIENT_SECRET })],
        secret: AUTH_SECRET,
        callbacks: {
            signIn(params) {
                if (params.profile && 'bot' in params.profile && params.profile.bot) {
                    return false;
                }
                return true;
            },
            async jwt(params) {
                let user: User | null = null;
                if (!params.account && params.token) {
                    return params.token;
                }
                user = await getUser(params.account?.provider ?? '', params.account?.providerAccountId ?? '');
                if (user == null) {
                    params.token.isNewUser = true;
                    const userToCreate = new UserCreateViewModel(
                        params.token.name!,
                        params.token.email!,
                        params.account!.provider,
                        params.account!.providerAccountId
                    );
                    user = await registerUser(userToCreate);
                    console.info(user);
                }
                params.token.id = user?.id;
                params.token.name = user?.profile?.handle;
                return params.token;
            },
            //user is only provided if using db auth
            //token is provided when using jwt auth
            //since we are using an external auth provider, rely on the token
            async session({ session, token, user }) {
                session.user.id = token.id;
                return session;
            }
        }
    }),
    sessionHandle,
    authorizationHandle
);
