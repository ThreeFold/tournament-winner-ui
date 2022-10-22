export default interface Player {
    id: string;
    usernamePrefix?: string;
    username: string;
    firstName: string;
    lastName: string;
    playerCreationDate: Date;
    games: Array<Game>;
    gameCharacters: Array<Character>;
    previousNames: Array<string>;

}
export interface Game {
    id: number;
    slug?: string;
    title: string;
    bannerImg: URL;
    iconImg: URL;
    
    gameCharacters: Array<Character>;
}
export interface Character {
    id: number;
    name: string;
    //this should be something like ssbu-mario
    referenceId: string;
    game: Game;
}
