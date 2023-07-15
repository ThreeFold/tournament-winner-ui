<script lang="ts">
	import { goto } from "$app/navigation";
	import type Community from "$lib/models/community";

    export let community: Community

    async function goToCommunity(){
        await goto(`/community/${community.slug ?? community.id}`);
    }
    $: communityHref = `/community/${community.slug ?? community.id}`;
</script>
    <div class="community-card">
        <a href={communityHref}>
            <p>{community.name}</p>
            <p>{community.description}</p>
        </a>
    </div>
<style lang="scss">
    .community-card {
        cursor: pointer;
        * {
            color: black;
            text-decoration:none;
        }
    }
</style>