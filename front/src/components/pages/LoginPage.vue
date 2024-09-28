<template>
    <div class="login-container">
      <h2 class="login-header">LOGOWANIE</h2>
      <form @submit.prevent="login">
        <div class="form-group">
          <label for="email">Login:</label>
          <input type="email" v-model="email" id="email" placeholder="Wpisz login" required />
        </div>
        <div class="form-group">
          <label for="password">Hasło:</label>
          <input type="password" v-model="password" id="password" placeholder="Wpisz hasło" required />
        </div>
        <button type="submit" class="btn">Zaloguj się</button>
      </form>
      <p>Nie masz konta? <span @click="showRegister">Zarejestruj się tutaj</span></p>
    </div>
  </template>
  
  <script>
  export default {
    name: "LoginPage",
    data() {
      return {
        email: '',
        password: ''
      };
    },
    methods: {
      login() {
        // Logika logowania
        localStorage.setItem('isLoggedIn', 'true');
        this.$emit('login'); // Emitujemy zdarzenie do App.vue
      },
      showRegister() {
        this.$emit('show-register'); // Emitujemy zdarzenie do App.vue, aby pokazać rejestrację
      }
    }
  };
  </script>
  
  <style scoped>
  .login-container {
    position: absolute;
    left: 50%;
    top: 50%;
    transform: translate(-50%, -50%);
    background-color: #d4f8c4;
    padding: 40px;
    width:500px;
    margin: 0 auto;
    border-radius: 20px;
    box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
    text-align: center;
  }
  
  .login-header {
    color: #333;
    font-size: 2rem;
    font-weight: 600;
    margin-bottom: 20px;
  }
  
  .form-group {
    margin-bottom: 20px;
    text-align: left;
  }
  
  .form-group label {
    display: block;
    font-size: 1.1rem;
    font-weight: 500;
    margin-bottom: 5px;
  }
  
  .form-group input {
    width: 100%;
    padding: 10px;
    font-size: 1rem;
    border: none;
    border-radius: 30px;
    background-color: #e0e4e9;
    color: #333;
  }
  
  .form-group input:focus {
    outline: none;
    box-shadow: 0 0 5px rgba(0, 0, 0, 0.1);
  }
  
  .btn {
    background-color: #4CAF50;
    color: white;
    padding: 10px 20px;
    border: none;
    border-radius: 30px;
    font-size: 1.2rem;
    cursor: pointer;
    width: 100%;
    margin-top: 20px;
  }
  
  .btn:hover {
    background-color: #45a049;
  }
  
  @media (max-width: 768px) {
    .login-container {
      width: 90%;
      padding: 30px;
    }
  
    .btn {
      font-size: 1rem;
    }
  }
  </style>
  