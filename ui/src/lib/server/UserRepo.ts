import { env } from '$env/dynamic/private';
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
        console.trace("Attempting to register user", userToCreate);
        const url = new URL('user/register', env.APP_API_BASE);
        const response = await fetch(url, {
            body: JSON.stringify(userToCreate),
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if(!response.ok) {
            console.warn("Response did not return an OK status code", response, await response.text());
            return null;
        }
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
        console.trace("Attempting to find the user", signInDetails);
        const url = new URL('user/details', env.APP_API_BASE);
        const response = await fetch(url, {
            body: signInDetails,
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (!response.ok) {
            console.warn(response.status, await response.text());
            return null;
        }
        return (await response.json()) as User;
    } catch (e) {
        console.error(e);
    }
    return null;
}
