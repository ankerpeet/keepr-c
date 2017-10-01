<template>
    <div class="container">
        <div class="keeps row">
            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3" v-for="keep in keeps">
                <img :src="keep.imgUrl" alt="">
                <h3>{{keep.title}}</h3>
                <p>{{keep.description}}</p>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'keeps',
        data() {
            return {
            }
        },
        mounted() {
            this.$store.dispatch('getKeeps');
        },
        computed: {
            keeps() {
                return this.$store.state.keeps
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    img {
        max-width: 200px;
    }
</style>