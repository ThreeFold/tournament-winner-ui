<script lang="ts">
import { page } from "$app/stores";
import type Community from "$lib/models/repo/community";
import type { LayoutData } from "./$types";

export let data: LayoutData;
$: communitySubPages = [
    {
        SubPageTitle: "Home",
        Url: data.communityHref,
        Label: "Community Home Page",
    },
    {
        SubPageTitle: "Games",
        Url: `${data.communityHref}/games`,
        Label: 'Games'
    },
    {
        SubPageTitle: "Players",
        Url: `${data.communityHref}/players`,
        Label: "Players",
    },
    {
        SubPageTitle: "Rankings",
        Url: `${data.communityHref}/ranks`,
        Label: `Rankings`
    }
];
$: pathname = $page.url.pathname;
$: activeSubPage = communitySubPages.find(v => v.Url?.includes(pathname));

</script>
<div class="content-header">
    <h1>{data.community?.name}</h1>
</div>
<div class="content-menu">
    {#each communitySubPages as communitySubPage}
    <a class="nav-item {activeSubPage === communitySubPage ? 'active' :''}"  href="{communitySubPage.Url}">{communitySubPage.Label}</a>
    {/each}
</div>
<div class="content-body">
    <slot></slot>
</div>

<style lang="scss" scoped>
    
.content-header {
    grid-area: title;
}
.content-menu {
    grid-area: content-nav;
    @media screen {
        @media(min-width:$large-breakpoint){
            padding-right:$size5;
        }
    }
}
.content-body {
    grid-area: content-body;
}
.content-menu {
    display:flex;
    flex-flow: column wrap;
    justify-content:flex-start;
    column-gap: $size5;
    .nav-item {
        padding: $size3 $size3;
        border-radius:$size2;
        text-decoration:none;
        text-align:center;
        color: $tw-primary;
        flex-basis:content;
        &.active {
            background-color: $tw-primary;
            color: $tw-primary-font-top;
        }
    }
}
</style>