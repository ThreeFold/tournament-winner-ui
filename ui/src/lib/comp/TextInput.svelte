<script lang="ts">
    export let label: string;
    export let id: string;
    export let value: string;
    export let required: boolean;
    export let style: string;

    $: inputName = `txt-${id}`;
</script>

<label for={id} {style}>
    {label}
    <input class="form-input" type="text" bind:value on:input id={inputName} {required} placeholder={label} />
</label>
