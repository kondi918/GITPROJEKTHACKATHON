<template>
    <div class="page container homePageContainer">
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
    </div>
  </template>
  
  <script>
  import SingleCategoryView from '../parts/SingleCategoryView.vue';
  
  export default {
    name: 'HomePage',
    components: {
      SingleCategoryView,
    },
  };
  </script>
  
  <style scoped>
  .homePageContainer {
    padding-top: 80px;
    height: 100vh;
  }
  </style>
  