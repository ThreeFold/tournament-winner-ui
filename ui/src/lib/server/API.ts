export async function get<ResponseType>(url: URL | string): Promise<ResponseType> {
    console.log(url);
    const response = await fetch(url, {
        'headers': {
            'Content-Type': 'application/json',
        }
    });
    return (await response.json()) as ResponseType;
}
