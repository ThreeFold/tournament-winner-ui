import type { Character, Game } from '$lib/models/player';
import type Player from '$lib/models/player';
import type { PageLoad } from './$types';

export const load: PageLoad = async ({params}) => {
    try{
        console.log("Grabbing players");
        //const response = await fetch(`http://localhost:5109/api/community/${params.communityIdentifier}/players`);
        const xrdR2: Game =
        {
            bannerImg: "https://www.google.com/",
            gameCharacters: new Array<Character>(),
            iconImg: "https://www.google.com/",
            id: 1,
            title: "Guilty Gear Xrd Rev2",
            slug: "GGXrdR2"
        };
        const leoWhitefang = {
            id: 1,
            name: "Leo Whitefang (Rev2)",
            referenceId: "LEOGGXrdR2",
            game: xrdR2
        };
        xrdR2.gameCharacters.push(leoWhitefang);
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
        console.log(players);
        return {
            players
        };
    } catch (e) {
        console.log(e);
    }
};