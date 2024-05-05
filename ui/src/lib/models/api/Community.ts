export default interface CreateCommunityRequest {
	name: string;
	slug?: string;
	description?: string;
	country: string;
	regionState: string;
	city?: string;
	links?: Array<string>;
}
