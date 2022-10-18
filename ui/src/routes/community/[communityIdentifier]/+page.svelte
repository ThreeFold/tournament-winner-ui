<script lang="ts">
    import type Community from '$lib/models/community';
import { community } from "$lib/store";
    
let thisCommunity: Community;
community.subscribe(value => {
    thisCommunity = value;
});
</script>
<p>{thisCommunity.description}</p>
<style lang="scss" scoped>
</style>