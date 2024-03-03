<script lang="ts">
    import type { PageData } from './$types';

    export let data: PageData;
</script>

<div>
    <a href="{data.communityHref}/games">&lt; Games</a>
    <h2>{data.game.title}</h2>
    <a href="/games/{data.game.slug ?? data.game.id}">Game Main Page</a>

    <h3>Pinned Rankings</h3>
    <table class="grid">
        <thead>
            <tr>
                <th>Rank</th>
                <th>Tag</th>
                <th>Characters</th>
                <th>Recent Events Entered</th>
                <th>Linked User</th>
            </tr>
        </thead>
        <tbody>
            {#each data.players as player}
                <tr>
                    <td>1.</td>
                    <td
                        >{#if player.usernamePrefix !== null}<span class="prefix"
                                >{player.usernamePrefix} |
                            </span>{/if}{player.username}</td
                    >
                    <td
                        >{player.gameCharacters
                            .slice(0, 2)
                            .map((c) => c.name)
                            .join(', ')}</td
                    >
                    <td />
                    <td />
                    <td />
                </tr>
            {/each}
        </tbody>
    </table>
</div>

<style lang="scss">
</style>
