<template>
    <div class="login">
        <h1>Login</h1>
        <form @submit.prevent="login">
            <div class="form-group">
                <label for="email">Email address:</label>
                <input v-model="user.email" type="email" class="form-control">
            </div>
            <div class="form-group">
                <label for="pwd">Password:</label>
                <input v-model="user.password" type="password" class="form-control">
            </div>
            <button type="submit" class="btn btn-default">Submit</button>
        </form>
    </div>
</template>

<script>
    export default {
        name: 'login',
        data() {
            return {
                user: {
                    email: "",
                    password: ""
                }
            }
        },
        methods: {
            login() {
                this.$store.dispatch('login', this.user);
            }
        }
    }

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>