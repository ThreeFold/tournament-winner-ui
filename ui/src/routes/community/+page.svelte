<script lang="ts">
	import CommunityCard from "$lib/comp/CommunityCard.svelte";

    export let data;
</script>

<div class="grid-title">
    <h1>Find your community here!</h1>
</div>
<div class="grid-content">
    {#each data.communities as community}
    <CommunityCard {community}></CommunityCard>
    {/each}
</div>
<style lang="scss">
    .content-header {
        grid-area: title;
    }
</style>