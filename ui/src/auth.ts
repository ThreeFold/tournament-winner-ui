import type { User } from '$lib/models/player';
import { UserCreateViewModel, getUser, registerUser } from '$lib/server/UserRepo';
import { SvelteKitAuth } from '@auth/sveltekit';
import Auth0 from '@auth/sveltekit/providers/auth0';

export const { handle, signIn, signOut } = SvelteKitAuth(async (event) => {
    const authOptions = {
        providers: [Auth0],
        trustHost: true,
        callbacks: {
            signIn(params: any) {
                if (params.profile && 'bot' in params.profile && params.profile.bot) {
                    return false;
                }
                return true;
            },
            async jwt(params: any) {
                let user: User | null = null;
                if (!params.account && params.token) {
                    return params.token;
                }
                user = await getUser(
                    params.account?.provider ?? '',
                    params.account?.providerAccountId ?? ''
                );
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
                params.token.accessToken = params.account.access_token;
                return params.token;
            },
            async session(params: any) {
                params.session.user.id = params.token.id;
                params.session.user.accessToken = params.accessToken;
                return params.session;
            }
        }
    };
    return authOptions;
});
