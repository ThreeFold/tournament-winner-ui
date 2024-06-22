<script lang="ts">
    import { page } from '$app/stores';
</script>

<div>
    <h1>{$page.data.community?.name}</h1>
</div>
<nav>
    <ul>
        <li style="background-color:;">
            <a href="{$page.data.communityHref}">Home</a> 
        </li>
        <li>
            <a class="" href="{$page.data.communityHref}/games">Games</a> 
        </li>
        <li>
            <a class="" href="{$page.data.communityHref}/Players">Players</a> 
        </li>
        <li>
            <a class="" href="{$page.data.communityHref}/games">Rankings</a> 
        </li>
    </ul>
</nav>
<div>
    <slot />
</div>

