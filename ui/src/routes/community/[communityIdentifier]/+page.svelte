<script lang="ts">
import type Community from '$lib/models/community';
import type { PageData } from './$types';

export let data: PageData;
</script>
<p>{data.community?.description}</p>
<style lang="scss" scoped>
</style>