<script lang="ts">
import type { Character, Game } from "$lib/models/player";
import type Player from "$lib/models/player";
import { communityPlayers } from '$lib/store';
let thisCommunityPlayers: Array<Player>;
communityPlayers.subscribe(value => {
    thisCommunityPlayers = value;
});
</script>
<div>
    <!--Filters-->
    
    <table class="grid">
        <thead>
            <tr>
                <td>Tag</td>
                <td>Games</td>
                <td>Recent Events Entered</td>
                <td>Linked User</td>
            </tr>
        </thead>
        <tbody>
            {#each thisCommunityPlayers as player}
                <tr>
                    <td><span class="prefix">{player.usernamePrefix} | </span>{player.username}</td>
                    <td>
                        {#each player.games as game}
                            <a href="/community/games/{game.slug}">{game.slug?.toLocaleUpperCase()}</a>
                        {/each}
                    </td>
                </tr>
            {/each}
        </tbody>
    </table>
    <!--Pagination or Infinite Scroll-->
</div>
<style lang="scss">
.grid {
    width:100%;
}
.prefix {
    color:$tw-light-gray;
}
</style>