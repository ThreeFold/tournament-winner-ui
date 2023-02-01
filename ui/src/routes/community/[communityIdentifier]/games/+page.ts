import type { Character, Game } from '$lib/models/player';
import type { PageLoad } from './$types';

export const load: PageLoad = async ({params}) => {
    try{
        console.log("Grabbing community games");
        //const response = await fetch(`http://localhost:5109/api/community/${params.communityIdentifier}/players`);
        const xrdR2: Game =
        {
            bannerImg: "/img/games/ggxrdr2/banner.jpg",
            gameCharacters: new Array<Character>(),
            iconImg: "/img/games/ggxrdr2/logo.png",
            id: 1,
            title: "Guilty Gear Xrd Rev2",
            slug: "ggxrdr2"
        };
        const leoWhitefang: Character = {
            id: 1,
            name: "Leo Whitefang (Rev2)",
            referenceId: "LEOGGXrdR2",
            game: xrdR2
        };
        xrdR2.gameCharacters.push(leoWhitefang);

        const ssbu: Game = {
            bannerImg: "/img/games/ssbu/banner.png",
            gameCharacters: new Array<Character>(),
            iconImg: "/img/games/ssbu/logo.png",
            id: 2,
            title: "Super Smash Bros. Ultimate",
            slug: "ssbu"
        };
        const ssbm: Game = {
            bannerImg: "/img/games/ssbm/banner.jpg",
            gameCharacters: new Array<Character>(),
            iconImg: "/img/games/ssbm/logo.png",
            id: 3,
            title: "Super Smash Bros. Melee",
            slug: "ssbm"
        };
        console.log("Loaded Games:", )
        return {
            games: [xrdR2, ssbu, ssbm]
        };
    } catch (e) {
        console.log(e);
    }
};