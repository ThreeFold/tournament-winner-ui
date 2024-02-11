export default interface Community {
	id: number;
	name: string;
	slug: string;
	description?: string;
    country: string;
    region: string;
    city: string;
	ownerUserId: string;
	insertDate: Date;
	links: Array<string>;
}

