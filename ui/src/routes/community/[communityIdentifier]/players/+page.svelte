<script lang="ts">
	import type { PageData } from './$types';
	export let data: PageData;
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
					<td><span class="prefix">{player.prefix} | </span>{player.name}</td>
					<td>
						{#each player.games as playerGame}
							<a href="{data.communityHref}/games/{playerGame.game.slug}"
								>{playerGame.game.slug?.toLocaleUpperCase()}</a
							>
						{/each}
					</td>
				</tr>
			{/each}
		</tbody>
	</table>
	<!--Pagination or Infinite Scroll-->
</div>
