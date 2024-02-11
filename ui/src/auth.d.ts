import { DefaultSession } from '@auth/sveltekit/node_modules/@auth/core/types';

declare module '@auth/sveltekit/node_modules/@auth/core/types' {
	interface Session {
		user: {
			isNewUser: boolean;
		} & DefaultSession['user'];
	}
    interface 
}
