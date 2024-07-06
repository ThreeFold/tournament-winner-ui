import type { User } from '../player';

export default interface Community {
    id: number;
    name: string;
    slug?: string;
    description: string;
    country: string;
    regionState: string;
    city: string;
    themeColor: Color;
    users: Array<CommunityUser>;
    insertDate?: Date;
    links: Array<SocialLink>;
}

export interface SocialLink {
    name:string;
    url:string;
}
export interface Color {
    red:number;
    green: number;
    blue: number;
    opacity: number;
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
