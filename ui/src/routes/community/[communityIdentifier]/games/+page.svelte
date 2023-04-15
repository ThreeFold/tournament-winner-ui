<script lang="ts">
	import { goto } from '$app/navigation';
	import type { Game } from '$lib/models/player';
    import type { PageData } from './$types';
    
    export let data: PageData;

    async function redirectToGame(game: Game){
        await goto(`${data.communityHref}/games/${game.slug ?? game.id}`);
    }
</script>

<div>
    
    {#if data.games}
    <div class="game-list">
        {#each data.games as game}
        <div class="game-card" on:click={() => redirectToGame(game)}>
            <div class="banner">
                <img src={game.bannerImg.toString()}/>
            </div>
            <div class="body">
                <div class="game-title">
                    <span class="icon game-icon"><img src={game.iconImg}/></span>
                    <span class="game-name">{game.title}</span>
                </div>
                <div class="game-desc">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque hendrerit lorem eget ligula luctus, nec tristique arcu ultrices. Duis placerat nisi eu libero elementum placerat. Sed et dolor facilisis, volutpat ligula vitae, dapibus nunc. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Sed eleifend erat a massa mollis sollicitudin. Morbi commodo lacinia libero, vel vehicula mauris rutrum eu. Nullam ac tortor erat. 
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
        &::hover {

        }
    }
</style>