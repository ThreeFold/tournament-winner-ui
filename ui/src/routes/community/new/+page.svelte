<script lang="ts">
    import type { PageData } from './$types';
    import type Community from '$lib/models/repo/community';
    import TextInput from '$lib/comp/TextInput.svelte';
    export let data: PageData;

    let newCommunity: Community = {
        id: 0,
        name: '',
        slug: '',
        description: '',
        ownerUserId: '',
        insertDate: new Date()
    };
    const countries = [{name:"United States of America", slug:"usa"}]
    let selectedCountry = 'usa';
    let stateRegionProvince = 'id';
    let customSlug = false;
    function handleSubmit(){

    }
    function generateSlug(){
        if(customSlug){
            return;
        }
        newCommunity.slug = newCommunity.name.split(' ')
        .map(x => x.charAt(0).toLowerCase())
        .join('');
    }
</script>
<h1 class="grid-title">New Community</h1>
<form class="grid-content" on:submit|preventDefault={handleSubmit}>

    <div class="name-input">
        <TextInput 
        bind:value={newCommunity.name} 
        on:input={generateSlug}
        id="community-name" 
        label="Community Name"
        required={true}
        style="flex-basis:85%"
        ></TextInput>
        <TextInput
        id="community-slug"
        label="Slug"
        bind:value={newCommunity.slug}
        on:input={() => customSlug = true}
        required={false}
        style="flex-basis:15%"
        ></TextInput>
    </div>
    <label for="community-description">Description</label>
    <textarea 
    class="form-input"
    id="community-description"
    bind:value={newCommunity.description}
    placeholder="Description"
    />
    <label>Country</label>
    <select value="selectedCountry" class="form-input">
        {#each countries as country }
            <option value={country.slug}>
                {country.name}
            </option>
        {/each}
    </select>
    <button type="submit">Create</button>
</form>

<style lang="scss">
    .name-input {
        display:flex;
    }
    input {
        display:block;
    }
    textarea {
        display:block;
    }
    select {
        display:block;
    }
</style>