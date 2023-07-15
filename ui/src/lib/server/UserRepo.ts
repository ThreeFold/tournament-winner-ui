
import { PUBLIC_APP_API_BASE } from '$env/static/public';
import type { AuthMethod } from '$lib/enum/AuthMethod';
import type { User } from '$lib/models/player';

export class UserCreateViewModel{
    username: string;
    email: string;
    authMethod: AuthMethod;
    authMethodValue: string;
    constructor(username: string, email: string, authMethod: AuthMethod, authMethodValue: string){
        this.username = username;
        this.email = email;
        this.authMethod = authMethod;
        this.authMethodValue = authMethodValue;
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

export async function getUserFromDiscordToken(discordId: string, email: string): Promise<User | null>{
    const signInDetails = JSON.stringify({
        id: discordId,
        email: email,
    });
    try{
        const response = await fetch(`${PUBLIC_APP_API_BASE}/user/DiscordSignIn`,
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