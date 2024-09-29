<!-- TakeQuizPage.vue -->
<template>
  <div class="page container takeQuizPageContainer">
    <!-- Stan ładowania -->
    <div v-if="loading" class="text-center mt-5">
      <span class="spinner-border text-light" role="status"></span>
      <span>Ładowanie quizu...</span>
    </div>

    <!-- Stan błędu -->
    <div v-else-if="error" class="text-center mt-5">
      <p>Błąd podczas ładowania quizu. Spróbuj ponownie później.</p>
    </div>

    <!-- Zawartość quizu -->
    <div v-else-if="quiz" class="quiz-content">
      <h2 class="text-center mb-4">{{ quiz.title }}</h2>
      <div v-if="currentQuestion">
        <div class="card">
          <div class="card-body">
            <h5>Pytanie {{ currentQuestionIndex + 1 }} z {{ quizQuestions.length }}</h5>
            <p class="card-text">{{ currentQuestion.questionText }}</p>
            <div v-if="!answered">
              <div class="list-group">
                <button
                  class="list-group-item list-group-item-action"
                  v-for="(answer, index) in shuffledAnswers"
                  :key="index"
                  @click="selectAnswer(answer)"
                >
                  {{ answer.answerText }}
                </button>
              </div>
            </div>
            <div v-else>
              <p>
                <strong>{{ isCorrect ? 'Poprawna odpowiedź!' : 'Niepoprawna odpowiedź.' }}</strong>
              </p>
              <p><strong>Wyjaśnienie:</strong> Lorem ipsum dolor sit amet...</p>
              <button class="btn btn-primary mt-3" @click="nextQuestion">
                {{ currentQuestionIndex + 1 < quizQuestions.length ? 'Następne pytanie' : 'Zakończ quiz' }}
              </button>
            </div>
          </div>
        </div>
      </div>

      <!-- Quiz zakończony -->
      <div v-else class="text-center">
        <h3>Quiz zakończony!</h3>
        <p>Zdobyłeś {{ score }} na {{ quizQuestions.length }} punktów.</p>
        <button class="btn btn-primary" @click="goBack">Powrót do listy quizów</button>
      </div>
    </div>

    <!-- Quiz nie znaleziony -->
    <div v-else-if="!loading && !error" class="text-center mt-5">
      <p>Nie znaleziono quizu.</p>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'TakeQuizPage',
  props: ['quizId'],
  data() {
    return {
      quiz: null, // Dane quizu
      quizQuestions: [], // Lista pytań
      currentQuestionIndex: 0, // Indeks bieżącego pytania
      currentQuestion: null, // Bieżące pytanie
      shuffledAnswers: [], // Tasowane odpowiedzi
      answered: false, // Czy pytanie zostało odpowiedziane
      isCorrect: false, // Czy odpowiedź była poprawna
      score: 0, // Wynik użytkownika
      loading: true, // Stan ładowania
      error: false, // Stan błędu
    };
  },
  created() {
    this.fetchQuizData();
  },
  methods: {
    async fetchQuizData() {
      try {
        console.log('Fetching quiz data for quizId:', this.quizId);
        // Pobierz dane quizu z użyciem query param zamiast route param
        const quizResponse = await axios.get('http://localhost:5080/Quiz/GetSingleQuiz', {
          params: { quizId: this.quizId }, // Zgodnie z backendem oczekuje 'categoryId'
        });
        this.quiz = quizResponse.data;
        console.log('Received quiz data:', this.quiz);

        // Sprawdź, czy quiz istnieje i ma pytania
        if (this.quiz && this.quiz.questionsIds && this.quiz.questionsIds.length > 0) {
          // Pobierz wszystkie pytania na podstawie questionsIds
          const questionPromises = this.quiz.questionsIds.map(id =>
            axios.get(`http://localhost:5080/Question/GetQuestion/${id}`)
          );
          const questionResponses = await Promise.all(questionPromises);
          this.quizQuestions = questionResponses.map(res => res.data);
          console.log('Received questions:', this.quizQuestions);

          // Ustaw pierwsze pytanie
          this.currentQuestion = this.quizQuestions[this.currentQuestionIndex];
          this.shuffleAnswers();
        } else {
          console.error('Quiz has no questions.');
          this.error = true;
        }
      } catch (error) {
        console.error('Error fetching quiz data:', error);
        this.error = true;
      } finally {
        this.loading = false;
      }
    },
    shuffleAnswers() {
      if (this.currentQuestion && this.currentQuestion.answers) {
        const answers = [...this.currentQuestion.answers];
        this.shuffledAnswers = answers.sort(() => Math.random() - 0.5);
        console.log('Shuffled answers:', this.shuffledAnswers);
      } else {
        console.error('No answers to shuffle.');
      }
    },
    selectAnswer(selectedAnswer) {
      this.answered = true;
      this.isCorrect = selectedAnswer.isCorrect;
      if (this.isCorrect) {
        this.score++;
      }
      console.log('Selected answer:', selectedAnswer, 'Is correct:', this.isCorrect);
    },
    nextQuestion() {
      this.answered = false;
      this.currentQuestionIndex++;
      if (this.currentQuestionIndex < this.quizQuestions.length) {
        this.currentQuestion = this.quizQuestions[this.currentQuestionIndex];
        this.shuffleAnswers();
      } else {
        this.currentQuestion = null; // Quiz zakończony
      }
    },
    goBack() {
      this.$router.push({ name: 'QuizList', params: { categoryName: this.quiz.category } });
    },
  },
};
</script>

<style scoped>
.takeQuizPageContainer {
  padding-top: 80px;
  color: white;
}

.card {
  background-color: #1b1b2f;
  color: white;
  border: none;
  border-radius: 15px;
}

.list-group-item {
  background-color: #e0e4e9;
  color: #333;
  margin-bottom: 10px;
  cursor: pointer;
}

.list-group-item:hover {
  background-color: #d4d8de;
}

.btn-primary {
  background-color: #4CAF50;
  border: none;
  border-radius: 30px;
}

.btn-primary:hover {
  background-color: #45a049;
}
</style>
