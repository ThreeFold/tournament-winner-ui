<script lang="ts">
    import type { PageData } from './$types';
	import { page } from '$app/stores';
    $: regObject = {
        username: $page.data.session?.user?.name,
        email: $page.data.session?.user?.email,
        provider: $page.data.session?.user?.provider,
        providerId: $page.data.session?.user?.providerId,
    }
</script>

<div class="grid-title">
    <h1>Create Your Account</h1>
</div>
<div class="grid-content">
    <form>
        <label for="username">Username</label>
        <input id="username" type="text" placeholder="Username" value={regObject.username}>
        <label for="email">Email</label>
        <input id="email" type="email" placeholder="Email" value={regObject.email} readonly={!!regObject.email}>
        <button type="submit">Create User</button>
    </form>
</div>