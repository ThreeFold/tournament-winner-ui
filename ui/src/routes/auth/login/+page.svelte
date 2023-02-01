<script lang="ts">

function handleLogin(e: Event){

}
</script>

<div>
    <form on:submit|preventDefault="{handleLogin}">
        <label for="login-username">Username or Email:</label>
        <input id="login-username" type="text" placeholder="Username or Email"/>
        <label for="login-password">Password:</label>
        <input id="login-password" type="password"/>
        <button type="submit">Login</button>
    </form>
</div>