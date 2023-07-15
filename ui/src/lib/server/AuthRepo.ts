import { PUBLIC_APP_API_BASE } from '$env/static/public';
import type { User } from '$lib/models/player';
import type { JWT } from "@auth/core/jwt";


export async function getUserFromDiscordToken(token: JWT): Promise<User | null>{
    console.log("Retrieving User from Discord Info");
    console.log(token);
    const signInDetails = JSON.stringify({
        id: token.sub,
        email: token.email,
    });
    const response = await fetch(`${PUBLIC_APP_API_BASE}/user/DiscordSignIn`,
    {
        body: signInDetails,
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        }
    });
    try{
        return await response.json() as User;
    } catch (e) {
        return null;
    }
}