<script lang="ts">
  import { page } from "$app/stores"
</script>
<div>
{#if $page.data.session}
<div>
    {#if $page.data.session.user?.image}
    <div>
        <!--UserImage-->
    </div>
    {:else}
    <div>
        <!--Default Image-->
    </div>
    {/if}
    <div>
        {$page.data.session.user?.name}
    </div>
</div>
{:else}
<div>
    <span>Guest 
        <a href="/account/login">Sign in</a> | <a href="/account/register">Register</a>
    </span>
</div>
{/if}
</div>
<style lang="scss">

</style>