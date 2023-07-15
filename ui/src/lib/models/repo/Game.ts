import type { GameCharacter } from "../player";

export default interface Game {
    id: number;
    slug?: string;
    title: string;
    bannerImage: string;
    iconImage: string;
    gameCharacters: Array<GameCharacter>;
    releaseDate: Date;
    insertDate: Date;
}
