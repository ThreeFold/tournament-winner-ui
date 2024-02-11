import type Game from './repo/Game';
import type Community from './repo/Community';

export default interface Player {
	playerId: string;
	prefix?: string;
    userId?: string;
    user?: User;
	name: string;
	playerCreationDate: Date;
	previousNames: Array<string>;
}

export interface User {
	userId: string;
	email: string;
    userCreationDate: Date;
    insertDate: Date;
	profile?: Profile;
}

export interface Profile {
    profileId: string;
    prefix: string;
    handle: string;
	firstName: string;
    lastName: string;
	profileImage: string;
    user?: User;
    insertDate: Date;
}
export interface ExternalLinks {
	icon: string;
	text: string;
	url: string;
}
export interface ContactMethod {
	type: string; //eg Phone Number, Discord, etc.
	value: string;
}
export interface UserAuthMethod {
	userAuthMethodId: number;
	userId: string;
	authValue: string;
	authProviderId: string;
}
export interface CommunityGame {
	communityGameId: number;
	community: Community;
	owner: User;
	game: Game;
	insertDate: Date;
}
