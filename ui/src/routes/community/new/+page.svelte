<script lang="ts">
	import { goto } from '$app/navigation';
	import type { ActionData, PageData } from './$types';
    import { enhance } from '$app/forms';

	export let data: PageData;
    export let form: ActionData;

    if(form?.success){
        goto(`/community/${form.communitySlug}`);
    }

	$: selectedCountry = '';
	$: stateRegionProvince = '';
    $: name = "";
    let slug = "";
    $: slug = customSlug ? slug : name.split(' ').map((x) => x.charAt(0).toLowerCase()).join('');
	let customSlug = false;

	$: links = new Array<string>();
	function addLink() {
		links = [...links, ''];
	}

	function removeLink(i: number) {
		links = links.toSpliced(i, 1);
	}
</script>

<h1 class="text-3xl mb-4">Submit a New Community</h1>
<form class="flex flex-col gap-3" method="POST" use:enhance>
 	<div>
		<label for="name" class="block pl-1">Community Name</label>
		<div>
			<input
				type="text"
				name="name"
				class="block w-full px-2 py-1 outline-none border border-slate-300 rounded-md focus:ring-2 ring-inset ring-emerald-300/70"
				placeholder="Community Name"
				bind:value={name}
				required
			/>
		</div>
	</div>
	<div>
		<label class="block pl-1" for="slug">Community Slug</label>
		<input
			type="text"
			name="slug"
			class="block w-full px-2 py-1 outline-none border border-slate-300 rounded-md focus:ring-2 ring-inset ring-emerald-300/70"
			placeholder="Slug"
			bind:value={slug}
			on:input={() => (customSlug = true)}
			required
		/>
	</div>
	<div>
		<label for="community-description">Description</label>
		<textarea
			id="community-description"
			rows="4"
            name="description"
			class="block w-full px-2 py-1 outline-none border border-slate-300 rounded-md focus:ring-2 ring-inset ring-emerald-300/70"
			placeholder="Description"
		/>
	</div>
	<p class="pl-1">Region Information</p>
	<div class="flex">
		<select
			name="country"
			class="bg-white px-2 py-1 outline-none border border-slate-300 rounded-l-md focus:ring-2 ring-inset ring-emerald-300/70"
			bind:value={selectedCountry}
			required
		>
			{#each data.countries as country}
				<option value={country.slug}>
					{country.name}
				</option>
			{/each}
		</select>
		<select
			name="region"
			class="bg-white px-2 py-1 outline-none border border-slate-300 focus:ring-2 ring-inset ring-emerald-300/70"
			placeholder="Country"
			disabled={!selectedCountry}
			bind:value={stateRegionProvince}
			required
		>
			{#each data.regions as region}
				<option value={region.slug}>
					{region.name}
				</option>
			{/each}
		</select>
		<input
			type="text"
            name="city"
			class="bg-white px-2 py-1 outline-none border border-slate-300 rounded-r-md focus:ring-2 ring-inset ring-emerald-300/70"
			placeholder="City"
		/>
	</div>
	<button type="button" on:click={addLink} class="bg-slate-300 hover:bg-slate-400 rounded-md"
		>Add Link</button
	>
	{#each links as link, i}
		<div class="flex items-center">
			<input
				class="grow px-2 py-1 outline-none border border-slate-300 rounded-l-md focus:ring-2 ring-inset ring-emerald-300/70"
				type="url"
				name={`link`}
				placeholder="Community External Link"
				bind:value={link}
			/>
			<button
				class="bg-red-700 outline-none border border-red-900 focus:ring-2 ring-inset ring-red-800/70 focus:bg-red-600 hover:bg-red-600 text-white rounded-r-md px-2 py-1"
				type="button"
				on:click|preventDefault={() => removeLink(i)}
			>
				-
			</button>
		</div>
	{/each}
	<button type="submit" class="ml-auto flex-end rounded-md p-2 bg-green-500 hover:bg-green-400"
		>Create</button
	>
</form>
