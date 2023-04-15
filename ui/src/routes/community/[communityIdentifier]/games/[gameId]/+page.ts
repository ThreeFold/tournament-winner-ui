import type Player from '$lib/models/player';
import type { Character, Game, GameCharacter } from '$lib/models/player';
import type { PageLoad } from './$types';

export const load = (async () => {
    const xrdR2: Game =
    {
        bannerImg: "/img/games/ggxrdr2/banner.jpg",
        gameCharacters: new Array<GameCharacter>(),
        iconImg: "/img/games/ggxrdr2/logo.png",
        id: 1,
        title: "Guilty Gear Xrd Rev2",
        slug: "rev2"
    };
    const leoWhitefang: GameCharacter = {
        id: 1,
        name: "Leo Whitefang (Rev2)",
        referenceId: "leo-rev2",
        games: [xrdR2],
        characterGame: xrdR2
    };
    const players: Array<Player> = [
        {
            firstName: "Nicholas",
            gameCharacters: [leoWhitefang],
            games: [xrdR2],
            id: "1",
            lastName: "McNew",
            playerCreationDate: new Date(),
            previousNames: new Array<string>(),
            username: "ThreeFold",
            usernamePrefix: "GSS"
        }
    ];
    return {
        game: xrdR2,
        players: players
    };
});