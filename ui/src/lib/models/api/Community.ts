export default interface CreateCommunityRequest {
    name: string;
    slug?: string;
    description?: string;
    country: string;
    regionState: string;
    city?: string;
    ownerId: string;
    links?: Array<string>;
}
