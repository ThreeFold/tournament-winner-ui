<script lang="ts">
    import DiscordAuthButton from '$lib/comp/ThirdPartyButtons/DiscordAuthButton.svelte';
import type { PageData } from './$types';
    
    export let data: PageData;
</script>

<DiscordAuthButton></DiscordAuthButton>
