import { PUBLIC_APP_API_BASE } from '$env/static/public';
import type { User } from '$lib/models/player';

export class UserCreateViewModel {
	username: string;
	email: string;
	authProviderId: string;
	authValue: string;
	constructor(username: string, email: string, authProviderId: string, authMethodValue: string) {
		this.username = username;
		this.email = email;
		this.authProviderId = authProviderId;
		this.authValue = authMethodValue;
	}
}

export async function registerUser(userToCreate: UserCreateViewModel): Promise<User | null> {
	try {
		console.log(userToCreate);
		const url = new URL('user/register', PUBLIC_APP_API_BASE);
		console.log(url);
		const response = await fetch(url, {
			body: JSON.stringify(userToCreate),
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			}
		});
		console.log(response);
		return (await response.json()) as User;
	} catch (e) {
		console.error(e);
	}
	return null;
}

export async function getUser(authProviderId: string, authValue: string): Promise<User | null> {
	const signInDetails = JSON.stringify({
		authProviderId,
		authValue
	});
	try {
		const url = new URL('user/signin', PUBLIC_APP_API_BASE);
		const response = await fetch(url, {
			body: signInDetails,
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			}
		});
		if (!response.ok) {
			return null;
		}
		return (await response.json()) as User;
	} catch (e) {
		console.error(e);
		return null;
	}
}
