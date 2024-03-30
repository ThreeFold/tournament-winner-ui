import type { User } from "../player";

export default interface Community {
    id: number;
    name: string;
    slug?: string;
    description: string;
    country: string;
    regionState: string;
    city: string;
    users: Array<CommunityUser>;
    insertDate?: Date;
    links: Array<string>;
}

export interface CommunityUser {
    id: number;
    communityId: number;
    community?: Community;
    userId: string;
    user: User;
    role: CommunityRole;
}

export enum CommunityRole {
    Owner = 1,
    Administrator = 2,
    Moderator = 3,
    Manager = 4,
    Member = 5
}
