<script lang="ts">
    import type { PageData } from './$types';
	import { goto } from '$app/navigation';
    export let data: PageData;

    console.log(data.session);
    if(!data.session){
        goto("/auth/signin");
    }
</script>

<div>
    <div>
        
    </div>
</div>