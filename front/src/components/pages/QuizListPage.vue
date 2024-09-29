<template>
    <div class="page container quizListPageContainer">
      <h2 class="text-center mb-4">Quizy z kategorii: {{ categoryName }}</h2>
      <div v-if="loading" class="text-center">
        <span class="spinner-border text-light" role="status"></span>
        <span>Ładowanie quizów...</span>
      </div>
      <div v-else>
        <div v-if="quizzes.length">
          <div class="row">
            <div class="col-md-6 col-lg-4 mb-4" v-for="quiz in quizzes" :key="quiz.id">
              <div class="card h-100">
                <div class="card-body">
                  <h5 class="card-title">{{ quiz.title }}</h5>
                  <p class="card-text">{{ quiz.description }}</p>
                  <p class="card-text"><small class="text-muted">Nagroda: {{ quiz.pointRewards }} pkt</small></p>
                  <button class="btn btn-primary">Rozpocznij Quiz</button>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div v-else class="text-center">
          <p>Brak quizów w tej kategorii.</p>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    name: 'QuizListPage',
    props: ['categoryName'],
    data() {
      return {
        quizzes: [],
        loading: true,
      };
    },
    created() {
      this.fetchQuizzes();
    },
    methods: {
      async fetchQuizzes() {
        try {
          const response = await axios.get('http://localhost:5080/Quiz/GetAllQuizes', {
            params: {
              category: this.categoryName,
            },
          });
          this.quizzes = response.data;
        } catch (error) {
          console.error('Błąd podczas pobierania quizów:', error);
        } finally {
          this.loading = false;
        }
      },
    },
  };
  </script>
  
  <style scoped>
  .quizListPageContainer {
    padding-top: 80px;
    color: white;
  }
  
  .card {
    background-color: #1b1b2f;
    color: white;
    border: none;
    border-radius: 15px;
  }
  
  .card-title {
    font-size: 1.5rem;
    font-weight: bold;
  }
  
  .card-text {
    font-size: 1rem;
  }
  
  .btn-primary {
    background-color: #4CAF50;
    border: none;
    border-radius: 30px;
  }
  
  .btn-primary:hover {
    background-color: #45a049;
  }
  
  .spinner-border {
    width: 3rem;
    height: 3rem;
  }
  </style>
  