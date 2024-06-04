<script lang="ts">
    import { page } from '$app/stores';
    console.log($page.data.communityGames);
</script>

<div>
    {#if $page.data}
        <div class="game-list">
            {#each $page.data.communityGames as communityGame}
                <div class="game-card">
                    <div class="banner">
                        <img
                            src={communityGame.game.bannerImage}
                            alt="{communityGame.game.title} Banner Image"
                        />
                    </div>
                    <div class="body">
                        <a
                            href="{$page.data.communityHref}/games/{communityGame.game.slug ??
                                communityGame.game.id}"
                        >
                            <div class="game-title">
                                <span class="icon game-icon"
                                    ><img
                                        src={communityGame.game.iconImage}
                                        alt="{communityGame.game.title} Icon Image"
                                    /></span
                                >
                                <span class="game-name">{communityGame.game.title}</span>
                            </div>
                        </a>
                        <div class="game-desc">
                            {communityGame.game.description}
                        </div>
                    </div>
                </div>
            {/each}
        </div>
    {/if}
</div>
