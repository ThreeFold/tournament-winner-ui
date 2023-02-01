export default interface Player {
    id: string;
    usernamePrefix?: string;
    username: string;
    firstName: string;
    lastName: string;
    playerCreationDate: Date;
    games: Array<Game>;
    gameCharacters: Array<GameCharacter>;
    previousNames: Array<string>;

}
export interface User {
    id: string;
    name: 
}
export interface Game {
    id: number;
    slug?: string;
    title: string;
    bannerImg: string;
    iconImg: string;
    
    gameCharacters: Array<GameCharacter>;
}
export interface Character {
    id: number;
    name: string;
    description?: string;
    games: Array<Game>;
}
export interface GameCharacter extends Character {
    //this should be something like ssbu-mario
    referenceId: string;
    characterGame: Game;
}
