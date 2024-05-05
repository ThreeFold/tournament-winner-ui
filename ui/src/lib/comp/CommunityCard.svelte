<script lang="ts">
	import { goto } from '$app/navigation';
	import type Community from '$lib/models/repo/Community';

	export let community: Community;

	async function goToCommunity() {
		await goto(`/community/${community.slug ?? community.id}`);
	}
	$: communityHref = `/community/${community.slug ?? community.id}`;
</script>

<div class="bg-slate-200 cursor-pointer">
	<a href={communityHref}>
		<p>{community.name}</p>
		<p>{community.description}</p>
	</a>
</div>
