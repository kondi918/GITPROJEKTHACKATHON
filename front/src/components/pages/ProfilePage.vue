<template>
    <div class="profile-page">
      <h1>Profil użytkownika</h1>
      <p><strong>Imię i nazwisko:</strong> {{ firstName }} {{ lastName }}</p>
      <p class="text-end"> Liczba punktów: 180</p>
  
      <div class="advice-section">
        <h2>Twoje porady:</h2>
        <p>{{ advice }}</p>
      </div>

      <div class="advice-section">
        <h2>Ostatnio rozwiązane quizy:</h2>
        <p>Quiz Astronomiczny</p>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        firstName: 'Jan',
        lastName: 'Kowalski',
        advice: this.getRandomAdvice()
      };
    },
    methods: {
      getRandomAdvice() {
        const adviceList = [
          'Dobrze Ci idzie z matematyki i fizyki, ale jeszcze musisz popracować nad historią.',
          'Świetnie radzisz sobie z geografią, spróbuj bardziej rozwijać swoje umiejętności językowe.',
          'Twoje wyniki z nauk ścisłych są imponujące, ale pracuj nad literaturą.',
          'Masz talent do programowania, ale pamiętaj o regularnej nauce języków obcych.'
        ];
        return adviceList[Math.floor(Math.random() * adviceList.length)];
      }
    }
  };
  </script>
  
  <style scoped>
  .profile-page {
    padding: 20px;
    background-color: #121212; /* Ciemne tło strony */
    color: #e0e0e0; /* Jasny tekst dla lepszej czytelności */
    min-height: 100vh;
  }
  
  h1 {
    font-size: 2rem;
    color: #fff; /* Biały kolor dla nagłówka */
    text-align: center;
  }
  
  .advice-section {
    margin-top: 20px;
    background-color: #1f1f1f; /* Lekko jaśniejsze tło dla sekcji z poradami */
    padding: 20px;
    border-radius: 10px;
    box-shadow: 0 0 10px rgba(255, 255, 255, 0.1); /* Subtelny biały cień */
  }
  
  h2 {
    color: #b3b3b3; /* Stonowany kolor nagłówka sekcji */
  }
  
  p {
    font-size: 1.2rem;
    color: #e0e0e0; /* Tekst w jasnym kolorze */
  }
  
  strong {
    color: #ffffff; /* Podkreślony tekst jest jaśniejszy */
  }
  </style>
  