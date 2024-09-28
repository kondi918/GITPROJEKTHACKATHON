<template>
  <div id="app">
    <template v-if="isLoggedIn">
      <!-- Główne komponenty aplikacji -->
      <UserProfileIcon />
      <CategoryPage />
      <ShopPage />
      <AppQuizPage />
    </template>
    <template v-else>
      <LoginPage v-if="showLogin" @login="login" @show-register="showRegisterPage" />
      <RegisterPage v-else @login="login" @show-login="showLoginPage" />
    </template>
  </div>
</template>

<script>
import AppQuizPage from './components/pages/AppQuizPage.vue';
import CategoryPage from './components/pages/CategoryPage.vue';
import ShopPage from './components/pages/ShopPage.vue';
import UserProfileIcon from './components/parts/UserProfileIcon.vue';
import LoginPage from './components/pages/LoginPage.vue';
import RegisterPage from './components/pages/RegisterPage.vue';

export default {
  name: 'App',
  components: {
    CategoryPage,
    ShopPage,
    UserProfileIcon,
    AppQuizPage,
    LoginPage,
    RegisterPage
  },
  data() {
    return {
      isLoggedIn: false,
      showLogin: true // Kontrola, czy pokazujemy stronę logowania
    };
  },
  methods: {
    login() {
      this.isLoggedIn = true;
      this.showLogin = true; // Przełącz na stronę główną po zalogowaniu
    },
    showRegisterPage() {
      this.showLogin = false; // Przełącz na stronę rejestracji
    },
    showLoginPage() {
      this.showLogin = true; // Przełącz na stronę logowania
    }
  }
};
</script>

<style>
@font-face {
    font-family: 'Fredoka'; 
    src: url('assets/Fredoka/Fredoka-VariableFont_wdth,wght.ttf');
}

#app {
  background-color: #000;
  overflow: hidden;
  min-height: 100vh;
}

.page {
  min-height: 100vh;
}

.font-fredoka {
  font-family: 'Fredoka';
}
</style>
