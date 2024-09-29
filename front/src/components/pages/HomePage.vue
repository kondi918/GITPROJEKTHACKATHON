<!-- HomePage.vue -->
<template>
    <div class="page container homePageContainer">
      <!-- Sekcja Kategorii -->
      <div class="row mt-5">
        <SingleCategoryView categoryName="Matematyka" categoryImageString="math-presentation.png"/>
        <SingleCategoryView categoryName="Polski" categoryImageString="book-arrangement.png" />
        <SingleCategoryView categoryName="Angielski" categoryImageString="language-translation.png" />
        <SingleCategoryView categoryName="Programowanie" categoryImageString="computer-science.png" />
      </div>
  
      <div class="row mt-5">
        <SingleCategoryView categoryName="Geografia" categoryImageString="geographic-navigation.png" />
        <SingleCategoryView categoryName="Historia" categoryImageString="history-book.png" />
        <SingleCategoryView categoryName="Fizyka" categoryImageString="physics-formula.png" />
        <SingleCategoryView categoryName="Muzyka" categoryImageString="musical-note.png" />
      </div>
  
      <!-- Sekcja Sklepu -->
      <div class="row mt-5">
        <ShopPage />
      </div>
  
      <!-- Sekcja Dodawania Quizów -->
      <div class="row mt-5">
        <AppQuizPage />
      </div>
    </div>
  </template>
  
  <script>
  import SingleCategoryView from '../parts/SingleCategoryView.vue';
  import ShopPage from './ShopPage.vue';
  import AppQuizPage from './AppQuizPage.vue';  
  
  export default {
    name: 'HomePage',
    components: {
      SingleCategoryView,
      ShopPage,
      AppQuizPage,
    },
  };
  </script>
  
  <style scoped>
  .homePageContainer {
    padding-top: 80px;
    min-height: 100vh;
  }
  
  /* Opcjonalnie: Dostosuj odstępy między sekcjami */
  .row + .row {
    margin-top: 40px;
  }
  </style>
  