import type { DefaultSession } from '@auth/sveltekit';
declare module '@auth/sveltekit' {
    interface Session {
        user: {
            id?: string;
        } & DefaultSession['user'];
    }
}

export {};
