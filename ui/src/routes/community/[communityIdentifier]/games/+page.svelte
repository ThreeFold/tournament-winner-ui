<script lang="ts">
    import type { PageData } from '../$types';
    
    export let data: PageData;
</script>

<div>
    
    {#if data}
    <div class="game-list">
        {#each data.communityGames as communityGame}
        <div class="game-card">
            <div class="banner">
                <img src={communityGame.game.bannerImage} alt="{communityGame.game.title} Banner Image"/>
            </div>
            <div class="body">
                <a href="{data.communityHref}/games/{communityGame.game.slug ?? communityGame.game.id}">
                    <div class="game-title">
                        <span class="icon game-icon"><img src={communityGame.game.iconImage} alt="{communityGame.game.title} Icon Image" /></span>
                        <span class="game-name">{communityGame.game.name}</span>
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
<style lang="scss">

    .game-list {
        display:flex;
        flex-flow: row wrap;
        column-gap: $size4;
        row-gap: $size3;
            .game-card {
            flex-basis: 30%;
        }
    }
    @mixin card-default {
        border:solid 1px #ccc;
        border-radius: 0.5rem;
        .banner {
            width:100%;
        }
    }
    .card {
        @include card-default();
    }
    .game-card {
        @include card-default();
        .banner {
            img {
                border-top-left-radius: 0.5rem;
                border-top-right-radius: 0.5rem;
                height:10rem;
                width:100%;
                object-fit: cover;
            }
        }
        .body {
            padding:$size2;
            .game-title {
                height:4rem;
                display:flex;
                align-items: center;
                column-gap: $size3;
                .game-icon {
                    img {
                        width:25px;
                        height:25px;
                        object-fit: scale-down;
                    }
                }
                .game-name {
                    font-size: $font-size-large;
                    overflow:hidden;
                    text-overflow: ellipsis;
                }
            }
            .game-desc {
                overflow:hidden;
                text-overflow: ellipsis;
            }
        }
    }
</style>