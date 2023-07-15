import { sveltekit } from '@sveltejs/kit/vite';
import mkcert from 'vite-plugin-mkcert';
import type { UserConfig } from 'vite';

const config: UserConfig = {
	server: {
		https: true
	},
	plugins: [sveltekit(), mkcert()]
};

export default config;
