<script lang="ts">
import { page } from "$app/stores";
import type Community from "$lib/models/community";
import { community } from "$lib/store";

let thisCommunity: Community;
$: communityHref = `/community/${thisCommunity.communityIdentifier}`;
community.subscribe(value => {
    thisCommunity = value;
});
$: communitySubPages = [
    {
        SubPageTitle: "Home",
        Url: communityHref,
        Label: "Community Home Page",
    },
    {
        SubPageTitle: "Players",
        Url: `${communityHref}/players`,
        Label: "Players",
    }
];
$: pathname = $page.url.pathname;
$: activeSubPage = communitySubPages.find(v => v.Url.includes(pathname));
</script>
<div class="community-page">
    <header>
        <h1>{thisCommunity.name}</h1>
        <span>{pathname}</span>
    </header>
    <nav>
        {#each communitySubPages as communitySubPage}
        <a class="nav-item {activeSubPage === communitySubPage ? 'active' :''}"  href="{communitySubPage.Url}">{communitySubPage.Label}</a>
        {/each}
    </nav>
    <div class="community-body">
        <slot></slot>
    </div>
</div>

<style lang="scss" scoped>
    
    nav {
        display:flex;
        flex-flow: row wrap;
        justify-content:space-evenly;
        column-gap: 2rem;

        .nav-item {
            padding: $size3 $size3;
            border-radius:$size2;
            text-decoration:none;
            color: $tw-primary;
            &.active {
                background-color: $tw-primary;
                color: $tw-primary-font-top;
            }
        }
    }
</style>