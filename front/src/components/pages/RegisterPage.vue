<template>
    <div class="register-container">
      <h2 class="register-header">ZAREJESTRUJ SIĘ</h2>
      <form @submit.prevent="register">
        <div class="form-group">
          <label for="nickname">Nick:</label>
          <input type="text" v-model="nickname" id="nickname" placeholder="Wpisz swój nick" required />
        </div>
        <div class="form-group">
          <label for="email">Email:</label>
          <input type="email" v-model="email" id="email" placeholder="Wpisz email" required />
        </div>
        <div class="form-group">
          <label for="password">Hasło:</label>
          <input type="password" v-model="password" id="password" placeholder="Wpisz hasło" required />
        </div>
        <button type="submit" class="btn">Zarejestruj się</button>
      </form>
      <p>Masz już konto? <span @click="showLogin">Zaloguj się tutaj</span></p>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    name: "RegisterPage",
    data() {
      return {
        nickname: '',
        email: '',
        password: ''
      };
    },
    methods: {
      async register() {
        try {
          const userData = {
            nick: this.nickname,
            email: this.email,
            password: this.password
          };
  
          const response = await axios.post('http://localhost:5080/Users/PostUser', userData);
  
          if (response.status === 200) { 
            alert('Rejestracja zakończona sukcesem');
            localStorage.setItem('isLoggedIn', 'true');
            this.$emit('login'); // Emitujemy zdarzenie do App.vue
          } else {
            alert('Wystąpił błąd podczas rejestracji.');
          }
        } catch (error) {
          console.error('Błąd rejestracji:', error);
          alert('Nie udało się zarejestrować. Sprawdź dane lub spróbuj ponownie później.');
        }
      },
      showLogin() {
        this.$emit('show-login'); // Emitujemy zdarzenie do App.vue, aby pokazać logowanie
      }
    }
  };
  </script>
  
  <style scoped>
  .register-container {
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
  
  .register-header {
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
    .register-container {
      width: 90%;
      padding: 30px;
    }
  
    .btn {
      font-size: 1rem;
    }
  }
  </style>
  