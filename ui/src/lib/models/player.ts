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
    name: string;
}
export interface Game {
    id: number;
    slug?: string;
    title: string;
    bannerImg: string;
    iconImg: string;

    characters: Array<GameCharacter>;
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
