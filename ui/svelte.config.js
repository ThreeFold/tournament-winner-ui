import adapter from '@sveltejs/adapter-auto';
import preprocess from 'svelte-preprocess';
import { dirname, join } from 'path';
import { fileURLToPath } from 'url';

const __dirname = dirname(fileURLToPath(import.meta.url));

/** @type {import('@sveltejs/kit').Config} */
const config = {
	// Consult https://github.com/sveltejs/svelte-preprocess
	// for more information about preprocessors
	preprocess: preprocess({
		postcss: {
			configFilePath: join(__dirname, 'postcss.config.js')
		}
	}),

	kit: {
		adapter: adapter()
	}
};

export default config;
