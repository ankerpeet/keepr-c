<template>
  <div id="app">
    <mynav></mynav>
    <router-view class="container"></router-view>
  </div>
</template>

<script>
  import mynav from './components/MyNav'
  export default {
    name: 'app',
    components: {
      mynav
    },
    mounted() {
      this.$store.dispatch('auth');
    }
  }

</script>

<style>
  @import url("https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css");

  #app {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
  }
</style>