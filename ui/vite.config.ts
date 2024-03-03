import { sveltekit } from '@sveltejs/kit/vite';
import type { UserConfig } from 'vite';
import fs from 'fs';

const config: UserConfig = {
    server: {},
    plugins: [sveltekit()]
};

export default config;
