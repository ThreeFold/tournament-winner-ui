<script lang="ts">
    import type Game from '$lib/models/repo/Game';
    import { onMount } from 'svelte';

    $: games = new Array<Game>();

    onMount(async () => {
        const response = await fetch('/games');
        if (!response.ok) {
            console.error(response.status, response.statusText);
        }

        games = (await response.json()) as Array<Game>;
    });
</script>
