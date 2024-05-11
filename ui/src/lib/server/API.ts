
export async function get<ResponseType>(url: URL | string): Promise<ResponseType> {
    const response = await fetch(url);
    return await response.json() as ResponseType;

}
