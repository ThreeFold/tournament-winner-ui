import { redirect, type Handle } from '@sveltejs/kit';
import { sequence } from '@sveltejs/kit/hooks';
import { handle as authHandle } from './auth';

const authorizationHandle: Handle = async ({ event, resolve }) => {
	return resolve(event);
};

export const handle: Handle = sequence(authHandle, authorizationHandle);
