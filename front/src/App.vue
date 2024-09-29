<template>
  <div id="app">
    <template v-if="isLoggedIn">
      <!-- Główne komponenty aplikacji -->
      <UserProfileIcon />
      <router-view />
    </template>
    <template v-else>
      <LoginPage v-if="showLogin" @login="login" @show-register="showRegisterPage" />
      <RegisterPage v-else @login="login" @show-login="showLoginPage" />
    </template>
  </div>
</template>

<script>
import UserProfileIcon from './components/parts/UserProfileIcon.vue';
import LoginPage from './components/pages/LoginPage.vue';
import RegisterPage from './components/pages/RegisterPage.vue';

export default {
  name: 'App',
  components: {
    UserProfileIcon,
    LoginPage,
    RegisterPage
  },
  data() {
    return {
      isLoggedIn: false,
      showLogin: true
    };
  },
  methods: {
    login() {
      this.isLoggedIn = true;
      this.showLogin = true;
    },
    showRegisterPage() {
      this.showLogin = false;
    },
    showLoginPage() {
      this.showLogin = true;
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
