import type Game from "./Game";
import type Community from "./community";

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
    prefix: string | null;
    tag: string;
    firstName: string;
    lastName: string;
    profileImage: string | null;
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