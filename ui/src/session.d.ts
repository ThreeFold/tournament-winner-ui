import type { DefaultSession } from '@auth/sveltekit';
import type { JWT } from '@auth/core/jwt';

declare module '@auth/sveltekit' {
    interface Session {
        user: {} & DefaultSession['user'];
    }
}
declare module '@auth/core/jwt' {
    interface JWT {
        user: {
            id: string;
            name: string;
        };
    }
}

export {};
