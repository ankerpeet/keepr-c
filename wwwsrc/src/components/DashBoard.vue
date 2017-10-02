<template>
    <div class="dashboard">
        <h1>{{user.userName}}</h1>
        <div v-if="user.email != null">
            <p>
                <a @click="logout">Logout</a>
            </p>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'dashboard',
        data() {
            return {
                createVaultModal: false
            }
        },
        mounted() {
            //this.$store.dispatch('getKeeps');
        },
        methods: {
            logout() {
                this.$store.dispatch('logout');
            }
        },
        computed: {
            user() {
                return this.$store.state.user;
            }
        }
    }

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>