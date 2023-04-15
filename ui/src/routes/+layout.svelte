<script>
	import UserHeaderTab from "$lib/comp/UserHeaderTab.svelte";

</script>
<div class="app-body">
    <nav class="main-nav">
        <a href="/">Home</a>
        <a href="/community">Communities</a>
        <a href="/ranks">Rankings</a>
        <a href="/vod">VODs</a>
        <a href="/account">Account</a>

        <UserHeaderTab></UserHeaderTab>
    </nav>
    <div class="body-wrapper">
        <div class="content">
            <slot></slot>
        </div>
    </div>
</div>
<style lang="scss">
</style>