import type { User } from "../player";

export default interface Community {
    id: number;
    name: string;
    slug?: string;
    description: string;
    country: string;
    regionState: string;
    city: string;
    ownerUserId: string;
    owner?: User;
    insertDate?: Date;
    links: Array<string>;
}
