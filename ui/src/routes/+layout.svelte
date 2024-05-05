<script>
	import '../app.css';
	import UserHeaderTab from '$lib/comp/UserHeaderTab.svelte';
</script>

<div>
	<nav class="flex p-4 bg-emerald-500 font-white items-center mb-6">
		<a class="px-2 py-3 hover:bg-emerald-200 hover:text-emerald-600 rounded-lg" href="/">Home</a>
		<a class="px-2 py-3 hover:bg-emerald-200 hover:text-emerald-600 rounded-lg" href="/community"
			>Communities</a
		>
		<a class="px-2 py-3 hover:bg-emerald-200 hover:text-emerald-600 rounded-lg" href="/ranks"
			>Rankings</a
		>
		<a class="px-2 py-3 hover:bg-emerald-200 hover:text-emerald-600 rounded-lg" href="/vod">VODs</a>
		<a class="px-2 py-3 hover:bg-emerald-200 hover:text-emerald-600 rounded-lg" href="/account"
			>Account</a
		>
		<UserHeaderTab class="ml-auto" />
	</nav>
	<div class="sm:max-w-full md:max-w-5xl m-auto">
		<slot />
	</div>
</div>

<style lang="postcss">
	:global(html) {
		background-color: theme(colors.slate.100);
	}
</style>
