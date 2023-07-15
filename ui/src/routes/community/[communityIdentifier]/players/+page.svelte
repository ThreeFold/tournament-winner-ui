<script lang="ts">
import type { PageData } from '../$types';
export let data: PageData;

console.log(data);
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
            {#each data.players as player}
                <tr>
                    <td><span class="prefix">{player.usernamePrefix} | </span>{player.username}</td>
                    <td>
                        {#each player.games as game}
                            <a href="{data.communityHref}/games/{game.slug}">{game.slug?.toLocaleUpperCase()}</a>
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