<script>
	import UserHeaderTab from "$lib/comp/UserHeaderTab.svelte";

</script>
<body>
    <div class="app-body">
        <nav class="main-nav">
            <a href="/">Home</a>
            <a href="/community">Communities</a>
            <a href="/ranks">Rankings</a>
            <a href="/vod">VODs</a>
            <a href="/account">Account</a>
            <UserHeaderTab class="pull-right"></UserHeaderTab>
        </nav>
        <div class="body-wrapper">
            <div class="content">
                <slot></slot>
            </div>
        </div>
    </div>
</body>
<style lang="scss">
    body {
        margin:0;
    }
    .main-nav {
        display:flex;
        background-color:$tw-primary;
        margin:0;
        color:$tw-primary-font-top;
        gap: $size4;
        align-items: center;
        padding-right:$size4;
        padding-left:$size4;
        a {
            color:$tw-primary-font-top;
            text-decoration: none;
            &:hover {
                background-color:$tw-dark-gray;
            }
        }

        :global(.pull-right) {
            margin-left:auto;
        }
    }
</style>