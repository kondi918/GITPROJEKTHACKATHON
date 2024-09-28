<template>
  <div id="app">
    <UserProfileIcon />
    <CategoryPage />
    <ShopPage />
    <AppQuizPage />
  </div>
</template>

<script>
import AppQuizPage from './components/pages/AppQuizPage.vue';
import CategoryPage from './components/pages/CategoryPage.vue';
import ShopPage from './components/pages/ShopPage.vue';
import UserProfileIcon from './components/parts/UserProfileIcon.vue';

export default {
  name: 'App',
  components: {
    CategoryPage,
    ShopPage,
    UserProfileIcon,
    AppQuizPage
  },
}
</script>

<style>
@font-face {
    font-family: 'Fredoka'; 
    src: url('assets/Fredoka/Fredoka-VariableFont_wdth,wght.ttf');
}

#app {
  background-color: #000;
  overflow: hidden;
  min-height: 200vh;
}

.page {
  min-height: 100vh;
}

.font-fredoka{
  font-family: 'Fredoka';
}
</style>
