<script lang="ts">
    import { page } from '$app/stores';
</script>

<div class="pb-4">
    <h1 class="text-5xl">{$page.data.community?.name}</h1>
</div>
<nav class="width-full">
    <ul class="grid grid-flow-col auto-cols-max justify-center space-x-4">
        <li>
            <a class="p-4 rounded hover:bg-emerald-500 transition-all" href="{$page.data.communityHref}">Home</a> 
        </li>
        <li>
            <a class="p-4 rounded hover:bg-emerald-500 transition-all" href="{$page.data.communityHref}/games">Games</a> 
        </li>
        <li>
            <a class="p-4 rounded hover:bg-emerald-500 transition-all" href="{$page.data.communityHref}/Players">Players</a> 
        </li>
        <li>
            <a class="p-4 rounded hover:bg-emerald-500 transition-all" href="{$page.data.communityHref}/games">Rankings</a> 
        </li>
    </ul>
</nav>
<div>
    <slot />
</div>

