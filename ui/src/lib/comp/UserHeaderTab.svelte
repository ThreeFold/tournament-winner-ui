<script lang="ts">
  import { page } from "$app/stores"
  let cssClass: string;
  export { cssClass as class};
</script>
<div class={cssClass}>
    {#if $page.data.session}
    <div class="user-nav-header">
        {#if $page.data.session.user?.image}
        <div>
            <img class="profile-picture" src={$page.data.session.user?.image} alt={`${$page.data.session.user?.name}'s Profile Image'`}/>
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
            <a href="/auth/signin">Sign in</a>
        </span>
    </div>
    {/if}
</div>
<style lang="scss">
.profile-picture {
    width: 40px;
    height: 40px;
    border-radius: 3px;
}
.user-nav-header {
    display:flex;
    align-items:center;
    gap:$size3;
}
</style>