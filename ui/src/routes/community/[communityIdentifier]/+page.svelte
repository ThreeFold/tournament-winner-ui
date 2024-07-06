<script lang="ts">
    import { page } from "$app/stores";

    console.log($page.data.community);
</script>

<p>{$page.data.community?.description}</p>

<ul>
    {#each $page.data.community.links as socialLink}
    <li><a href={socialLink}>Link</a></li>
    {/each}
</ul>
