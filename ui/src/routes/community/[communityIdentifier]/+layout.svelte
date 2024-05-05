<script lang="ts">
	import { page } from '$app/stores';
	import type { LayoutData } from './$types';

	export let data: LayoutData;
	$: communitySubPages = [
		{
			SubPageTitle: 'Home',
			Url: data.communityHref,
			Label: 'Community Home Page'
		},
		{
			SubPageTitle: 'Games',
			Url: `${data.communityHref}/games`,
			Label: 'Games'
		},
		{
			SubPageTitle: 'Players',
			Url: `${data.communityHref}/players`,
			Label: 'Players'
		},
		{
			SubPageTitle: 'Rankings',
			Url: `${data.communityHref}/ranks`,
			Label: `Rankings`
		}
	];
	$: pathname = $page.url.pathname;
	$: activeSubPage = communitySubPages.find((v) => v.Url?.includes(pathname));
</script>

<div>
	<h1>{data.community?.name}</h1>
</div>
<div>
	{#each communitySubPages as communitySubPage}
		<a
			class="nav-item {activeSubPage === communitySubPage ? 'active' : ''}"
			href={communitySubPage.Url}>{communitySubPage.Label}</a
		>
	{/each}
</div>
<div>
	<slot />
</div>
