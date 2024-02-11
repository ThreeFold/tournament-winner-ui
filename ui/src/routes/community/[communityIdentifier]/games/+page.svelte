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
						<img
							src={communityGame.game.bannerImage}
							alt="{communityGame.game.title} Banner Image"
						/>
					</div>
					<div class="body">
						<a href="{data.communityHref}/games/{communityGame.game.slug ?? communityGame.game.id}">
							<div class="game-title">
								<span class="icon game-icon"
									><img
										src={communityGame.game.iconImage}
										alt="{communityGame.game.title} Icon Image"
									/></span
								>
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
