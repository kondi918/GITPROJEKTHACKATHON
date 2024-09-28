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
  mounted() {
    window.addEventListener('wheel', this.handleScroll);
  },
  beforeUnmount() {
    window.removeEventListener('wheel', this.handleScroll);
  },
  methods: {
    handleScroll(event) {
      if (event.deltaY != 0) {
        this.scrollToNextSection();
      } else {
        this.scrollToPrevSection();
      }
    },
    scrollToNextSection() {
      const currentSection = Math.floor(window.scrollY / window.innerHeight);
      const nextSection = currentSection + 1;
      const sections = document.querySelectorAll('.page');
      
      if (nextSection < sections.length) {
        sections[nextSection].scrollIntoView({ behavior: 'smooth' });
      }
    },
    scrollToPrevSection() {
      const currentSection = Math.floor(window.scrollY / window.innerHeight);
      const prevSection = currentSection - 1;
      const sections = document.querySelectorAll('.page');

      if (prevSection >= 0) {
        sections[prevSection].scrollIntoView({ behavior: 'smooth' });
      }
    },
  }
}
</script>

<style>
#app {
  background-color: #000;
  overflow: hidden;
}
</style>
