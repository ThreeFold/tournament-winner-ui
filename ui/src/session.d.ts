import type { DefaultSession } from '@auth/sveltekit';
declare module '@auth/sveltekit' {
    interface Session {
        user: {
            accessToken?: string;
        } & DefaultSession['user'];
    }
}

export {};
