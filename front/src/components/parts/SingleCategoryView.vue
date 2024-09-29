<template>
    <div class="col-12 col-md-6 col-lg-4 col-xl-3">
      <div class="categoryViewContainer" @click="goToCategory">
        <div class="categoryIcon">
          <img :src="getImageUrl(categoryImageString)" alt="category image" />
        </div>
        <div class="categoryName font-fredoka">
          {{ categoryName }}
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    name: 'SingleCategoryView',
    props: {
      categoryName: String,
      categoryImageString: String
    },
    methods: {
      getImageUrl(imagePath) {
        return require(`@/assets/icons/${imagePath}`);
      },
      goToCategory() {
        this.$router.push({ name: 'QuizList', params: { categoryName: this.categoryName } });
      }
    }
  };
  </script>
  
  <style scoped>
  .categoryViewContainer {
    height: 30vh;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    color: white;
    cursor: pointer;
  }
  
  .categoryName {
    font-size: 24px;
    letter-spacing: 2.5px;
    text-transform: uppercase;
    color: #DDFFDD;
  }
  
  .categoryIcon img {
    filter: invert(1);
    width: 100px;
  }
  </style>
  