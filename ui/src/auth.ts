import type { User } from '$lib/models/player';
import { UserCreateViewModel, getUser, registerUser } from '$lib/server/UserRepo';
import { SvelteKitAuth, type SvelteKitAuthConfig} from '@auth/sveltekit';
import Auth0 from '@auth/sveltekit/providers/auth0';

export const { handle, signIn, signOut } = SvelteKitAuth(async (event) => {
    const authOptions: SvelteKitAuthConfig = {
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
                    console.info("Token Exists", params.token);
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
                }
                params.token.user = {
                    name: params.token.name ?? user?.profile?.handle,
                    id: params.token.id ?? user?.id
                };
                console.info("Built Token", params.token);
                return params.token;
            },
            async session({session, token}) {
                session.user.id = token.user.id;
                session.user.name = token.user.name;
                console.info("Built session", session);
                return session;
            }
        }
    };
    return authOptions;
});
