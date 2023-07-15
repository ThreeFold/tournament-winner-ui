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
    :global{
        * { 
            font-family: $base-font-family;
        }
        .app-body {
            display:grid;
            @media (min-width:$large-breakpoint){
                grid-template-areas: "main-nav main-nav main-nav" "left-pad body-content right-pad";
                grid-template-rows: $size6 1fr;
                grid-template-columns: 1fr 5fr 1fr;
            }
            @media (min-width:$small-breakpoint) and (max-width:$large-breakpoint){
                grid-template-areas: "main-nav" "body-content";
                grid-template-rows: minmax($size1,$size6) 1fr;
                grid-template-columns: 1fr;
            }
            
            .main-nav {
                grid-area:main-nav;
            }
            .body-wrapper {
                grid-area: body-content;
            }
        }
        .content {
            display:grid;
            @media (min-width:$large-breakpoint){
                grid-template-areas: "title title" "content-nav content-body";
                grid-template-columns: 10rem 1fr;
            }
            @media (max-width:$large-breakpoint){
                grid-template-areas: "title" "content-nav" "content-body";
            }
        }

        .grid-title {
            grid-area: title;
        }
        .grid-content-nav {
            grid-area: content-nav;
        }
        .grid-content-body {
            grid-area: content-body;
        }
        .grid-content {
            grid-area: content-nav / content-nav / content-body / content-body;
        }

        .form-input {
            margin-bottom:$size3;
        }
    }
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