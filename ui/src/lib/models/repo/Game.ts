export default interface Game {
    id: number;
    slug?: string;
    title: string;
    description: string;
    bannerImage: string;
    iconImage: string;
    gameCharacters: Array<GameCharacter>;
    releaseDate: Date;
    insertDate: Date;
}

export interface GameSeries {
    id: number;
    name: string;
    games: Array<Game>;
}

export interface GameCharacter {
    id: number;
    shortName: string;
    name: string;
    image: string;
    game: Game;
}
