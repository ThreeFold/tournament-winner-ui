<script lang="ts">
	import { signIn } from '@auth/sveltekit/client';
	export let mainColor: string;
	export let fontColor: string;
	export let imageLink: string;
	export let providerAuthName: string;

	function handleClick() {
		signIn(providerAuthName.toLowerCase());
	}
</script>

<button
	class="auth-button"
	style="background-color:{mainColor};color:{fontColor};"
	on:click={handleClick}
>
	<img src={imageLink} alt="{providerAuthName} Logo" />
	<span>Sign in with {providerAuthName}</span>
</button>
