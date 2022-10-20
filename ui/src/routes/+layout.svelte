<div class="app-body">
    <nav class="main-nav">
        <a href="/">Home</a>
        <a href="/community">Communities</a>
        <a href="/ranks">Rankings</a>
        <a href="/vod">VODs</a>
        <a href="/account">Account</a>
    </nav>
    <div class="body-wrapper">
        <div class="content">
            <slot></slot>
        </div>
    </div>
</div>
<style lang="scss">
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
        grid-template-columns: 15rem 1fr;
    }
    @media (max-width:$large-breakpoint){
        grid-template-areas: "title" "content-nav" "content-body";
    }

}
</style>