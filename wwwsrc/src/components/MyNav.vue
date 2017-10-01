<template>
    <div class="mynav">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <router-link to="/" class="navbar-brand">Keepr</router-link>
                </div>
                <div class="nav navbar-nav navbar-right">
                    <ul>
                        <li>
                            <form class="nav navbar-form">
                                <div class="input-group">
                                    <input type="text" class="form-control" placeholder="Search">
                                    <div class="input-group-btn">
                                        <button class="btn btn-default" type="submit">
                                              <i class="glyphicon glyphicon-search"></i>
                                        </button>
                                    </div>
                                </div>
                            </form>
                        </li>
                    </ul>
                    <ul v-if="user.email != null" class="nav navbar-nav">
                        <li>
                            <a @click="logout">Logout</a>
                        </li>
                    </ul>
                    <ul v-else class="nav navbar-nav">
                        <li>
                            <router-link to="Login">Sign In</router-link>
                        </li>
                        <li>
                            <router-link to="SignUp">Sign Up</router-link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </div>
</template>

<script>
    export default {
        name: 'mynav',
        data() {
            return {
            }
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
    .navbar {
        border-radius: 0;
    }
</style>