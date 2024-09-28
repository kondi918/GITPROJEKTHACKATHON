<template>
  <div id="app">
    <UserProfileIcon />
    <CategoryPage />
    <ShopPage />
  </div>
</template>

<script>
import CategoryPage from './components/pages/CategoryPage.vue';
import ShopPage from './components/pages/ShopPage.vue';
import UserProfileIcon from './components/parts/UserProfileIcon.vue';

export default {
  name: 'App',
  components: {
    CategoryPage,
    ShopPage,
    UserProfileIcon
  },
}
</script>

<style>
#app {
  background-color: #000;
  overflow: hidden;
}
</style>
