<script lang="ts">
	import CommunityCard from '$lib/comp/CommunityCard.svelte';
	import type { PageData } from './$types';

	export let data: PageData;
</script>

<div class="flex items-center">
	<h1 class="text-3xl">Find your community here!</h1>
	<a
		href="/community/new"
		type="button"
		class="text-xs ml-auto bg-slate-300 hover:bg-slate-400 px-3 py-2 rounded-lg">+ Create</a
	>
</div>
<div class="sm:grid-cols-1 md:grid-cols-4 lg:grid-cols-6">
	{#each data.communities as community}
		<CommunityCard {community} />
	{/each}
</div>
