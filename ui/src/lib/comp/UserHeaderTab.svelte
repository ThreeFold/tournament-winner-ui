<script lang="ts">
    import { page } from '$app/stores';
    import { signIn, signOut } from '@auth/sveltekit/client';
    let cssClass: string | undefined | null;
    let hovering = false;
    export { cssClass as class };
</script>

<div class={cssClass}>
    {#if $page.data.session}
        <div on:mouseenter={() => hovering = true} on:mouseleave={() => hovering = false} class="user-nav-header relative">
            {#if $page.data.session.user?.image}
                <div>
                    <img
                        class="profile-picture"
                        src={$page.data.session.user?.image}
                        alt={`${$page.data.session.user?.name}'s Profile Image'`}
                    />
                </div>
            {:else}
                <div>
                    <!--Default Image-->
                </div>
            {/if}
            <div>
                {$page.data.session.user?.name}
            </div>
            <div class="bg-emerald-500 rounded border-2 border-emerald-200 absolute right-0 -bottom-28 p-2 w-36 {!hovering ? 'invisible' : '' }">
                <ul>
                    <li class="hover:bg-emerald-200 rounded px-2 py-1"><a href="/account">View Account</a></li>
                    <li class="hover:bg-emerald-200 rounded px-2 py-1"><a href="/account/settings">Settings</a></li>
                    <li class="hover:bg-emerald-200 rounded px-2 py-1"><button on:click={async () => signOut()}>Sign Out</button></li>
                </ul>
            </div>
        </div>
    {:else}
        <div>
            <span
                >Guest
                <button on:click|preventDefault={async () => signIn("auth0")}>Sign In</button>
            </span>
        </div>
    {/if}
</div>

<style>
    .profile-picture {
        width: 40px;
        height: 40px;
        border-radius: 3px;
    }
    .user-nav-header {
        display: flex;
        align-items: center;
        gap: var(--size3);
    }
</style>
