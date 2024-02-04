
import { PUBLIC_APP_API_BASE } from '$env/static/public';
import type { User } from '$lib/models/player';

export class UserCreateViewModel{
    username: string;
    email: string;
    authProviderId: string;
    authValue: string;
    constructor(username: string, email: string, authProviderId: string, authMethodValue: string){
        this.username = username;
        this.email = email;
        this.authProviderId = authProviderId;
        this.authValue = authMethodValue;
    }
}

export async function registerUser(userToCreate: UserCreateViewModel): Promise<User | null> {
    try {
        const response = await fetch(`${PUBLIC_APP_API_BASE}/user/register`, {
            body: JSON.stringify(userToCreate),
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            }
        });
        return await response.json() as User;
    }
    catch (e){
        console.error(e);
    }
    return null;
}

export async function getUser(authProviderId: string, authValue: string): Promise<User | null>{
    const signInDetails = JSON.stringify({
        authProviderId,
        authValue,
    });
    try{
        const response = await fetch(`${PUBLIC_APP_API_BASE}/user/signin`,
        {
            body: signInDetails,
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            }
        });
        if(!response.ok) {
            return null;
        }
        return await response.json() as User;
    } catch (e) {
        console.error(e);
        return null;
    }
}
