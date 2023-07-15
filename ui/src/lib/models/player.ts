
import type { AuthMethod } from "$lib/enum/AuthMethod";
import type Game from "./repo/Game";
import type Community from "./repo/community";

export default interface Player {
    id: string;
    usernamePrefix?: string;
    username: string;
    firstName: string;
    lastName: string;
    playerCreationDate: Date;
    playerGames: Array<PlayerGame>;
    previousNames: Array<string>;

}
export interface PlayerGame {

}
export interface PlayerGameCharacter {

}
export interface User {
    id: string;
    email: string;
    profile?: Profile;
}
export interface Profile {
    name: string;
    profilePicture: string;
    heading: string;
    biography: string;
    links: Array<ExternalLinks>;
    contactMethods: Array<ContactMethod>;
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
    id: number;
    userId: string;
    authValue: string;
    authMethod: AuthMethod;
}
export interface Character {
    id: number;
    name: string;
    description?: string;
    games: Array<GameCharacter>;
}
export interface GameCharacter {
    //this should be something like ssbu-mario
    referenceId: string;
    game: Game;
    character: Character;
    description?: string;
    wikiLink?: string;
}

export interface CommunityGame {
    communityGameId: number;
    community: Community;
    owner: User;
    game: Game;
    insertDate: Date;
}