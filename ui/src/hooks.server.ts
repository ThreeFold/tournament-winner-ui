import type { Handle, HandleFetch, HandleServerError } from "@sveltejs/kit";

export const handle: Handle = async ({event, resolve}) => {
    if (event.url.pathname.startsWith('/auth/callback')) {
        console.log(event.route);
        return new Response('custom response');
    }
    
    const response = await resolve(event);
    return response;
}