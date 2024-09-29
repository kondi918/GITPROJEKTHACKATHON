<!-- TakeQuizPage.vue -->
<template>
  <div class="page container takeQuizPageContainer">
    <!-- Strona tytułowa quizu -->
    <div v-if="!quizStarted && !quizFinished" class="quiz-landing">
      <h2 class="text-center mb-4">{{ quiz.title }}</h2>
      <p class="text-center">{{ quiz.description }}</p>
      <p class="text-center"><strong>Punkty do zdobycia:</strong> {{ quiz.pointRewards }}</p>
      <div class="text-center mt-4">
        <button class="btn btn-primary" @click="startQuiz">Rozpocznij quiz</button>
      </div>
    </div>

    <!-- Sekcja quizu -->
    <div v-else-if="quizStarted && !quizFinished" class="quiz-content">
      <h2 class="text-center mb-4">{{ quiz.title }}</h2>
      
      <!-- Bieżące pytanie -->
      <div class="card">
        <div class="card-body">
          <h5>Pytanie {{ currentQuestionIndex + 1 }} z {{ questions.length }}</h5>
          <p class="card-text">{{ currentQuestion.questionText }}</p>
          
          <!-- Odpowiedzi -->
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

          <!-- Wyjaśnienie po odpowiedzi -->
          <div v-else class="explanation-section">
            <p>
              <strong>{{ isCorrect ? 'Poprawna odpowiedź!' : 'Niepoprawna odpowiedź.' }}</strong>
            </p>
            <p><strong>Wyjaśnienie:</strong> {{ currentQuestion.explanation }}</p>
            <button class="btn btn-primary mt-3" @click="nextQuestion">
              {{ currentQuestionIndex + 1 < questions.length ? 'Następne pytanie' : 'Zakończ quiz' }}
            </button>
          </div>
        </div>
      </div>
    </div>

    <!-- Podsumowanie quizu -->
    <div v-else-if="quizFinished" class="summary-section">
      <h3 class="text-center">Quiz zakończony!</h3>
      <p class="text-center">Zdobyłeś {{ score }} na {{ questions.length }} punktów.</p>
      <div class="text-center mt-4">
        <button class="btn btn-primary" @click="restartQuiz">Rozpocznij ponownie</button>
      </div>
    </div>

    <!-- Quiz nie znaleziony -->
    <div v-else class="text-center mt-5">
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
      quiz: {
        title: 'Ładowanie quizu...',
        description: '',
        pointRewards: 0,
      },
      questions: [
        {
          questionText: 'Jakie jest stolicą Polski?',
          answers: [
            { answerText: 'Warszawa', isCorrect: true },
            { answerText: 'Kraków', isCorrect: false },
            { answerText: 'Gdańsk', isCorrect: false },
            { answerText: 'Wrocław', isCorrect: false },
          ],
          explanation: 'Warszawa jest stolicą Polski.',
        },
        {
          questionText: 'Który pierwiastek ma symbol "O"?',
          answers: [
            { answerText: 'Złoto', isCorrect: false },
            { answerText: 'Srebro', isCorrect: false },
            { answerText: 'Tlen', isCorrect: true },
            { answerText: 'Węgiel', isCorrect: false },
          ],
          explanation: 'Tlen ma symbol "O".',
        },
        {
          questionText: 'Kto napisał "Pana Tadeusza"?',
          answers: [
            { answerText: 'Adam Mickiewicz', isCorrect: true },
            { answerText: 'Juliusz Słowacki', isCorrect: false },
            { answerText: 'Henryk Sienkiewicz', isCorrect: false },
            { answerText: 'Bolesław Prus', isCorrect: false },
          ],
          explanation: '"Pan Tadeusz" napisał Adam Mickiewicz.',
        },
      ],
      currentQuestionIndex: 0, // Indeks bieżącego pytania
      currentQuestion: null, // Bieżące pytanie
      shuffledAnswers: [], // Tasowane odpowiedzi
      answered: false, // Czy pytanie zostało odpowiedziane
      isCorrect: false, // Czy odpowiedź była poprawna
      score: 0, // Wynik użytkownika
      quizStarted: false, // Czy quiz został rozpoczęty
      quizFinished: false, // Czy quiz został zakończony
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
        console.log('Pobieranie danych quizu dla quizId:', this.quizId);
        // Pobierz dane quizu z użyciem query param
        const quizResponse = await axios.get('http://localhost:5080/Quiz/GetSingleQuiz', {
          params: { quizId: this.quizId }, // Zgodnie z backendem oczekuje 'quizId'
        });
        this.quiz = quizResponse.data;
        console.log('Odebrane dane quizu:', this.quiz);
      } catch (error) {
        console.error('Błąd podczas pobierania danych quizu:', error);
        this.error = true;
      } finally {
        this.loading = false;
      }
    },
    startQuiz() {
      this.quizStarted = true;
      this.currentQuestionIndex = 0;
      this.currentQuestion = this.questions[this.currentQuestionIndex];
      this.shuffleAnswers();
    },
    shuffleAnswers() {
      if (this.currentQuestion && this.currentQuestion.answers) {
        const answers = [...this.currentQuestion.answers];
        this.shuffledAnswers = answers.sort(() => Math.random() - 0.5);
      }
    },
    selectAnswer(selectedAnswer) {
      this.answered = true;
      this.isCorrect = selectedAnswer.isCorrect;
      if (this.isCorrect) {
        this.score++;
      }
    },
    nextQuestion() {
      this.answered = false;
      this.currentQuestionIndex++;
      if (this.currentQuestionIndex < this.questions.length) {
        this.currentQuestion = this.questions[this.currentQuestionIndex];
        this.shuffleAnswers();
      } else {
        this.quizFinished = true;
      }
    },
    restartQuiz() {
      this.quizStarted = false;
      this.quizFinished = false;
      this.score = 0;
      this.currentQuestionIndex = 0;
      this.currentQuestion = null;
      this.shuffledAnswers = [];
      this.answered = false;
      this.isCorrect = false;
    },
  },
};
</script>

<style scoped>
.takeQuizPageContainer {
  padding-top: 80px;
  color: white;
}

.quiz-landing {
  background-color: #1b1b2f;
  padding: 40px;
  border-radius: 15px;
}

.quiz-landing h2 {
  color: #ffffff;
}

.quiz-landing p {
  color: #dddddd;
}

.quiz-landing .btn-primary {
  background-color: #4caf50;
  border: none;
  border-radius: 30px;
  padding: 10px 20px;
  font-size: 16px;
}

.quiz-landing .btn-primary:hover {
  background-color: #45a049;
}

.quiz-content {
  margin-top: 20px;
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

.explanation-section {
  margin-top: 20px;
  background-color: #2c2c54;
  padding: 15px;
  border-radius: 10px;
}

.summary-section {
  background-color: #1b1b2f;
  padding: 40px;
  border-radius: 15px;
}

.summary-section h3 {
  color: #ffffff;
}

.summary-section p {
  color: #dddddd;
}

.summary-section .btn-primary {
  background-color: #4caf50;
  border: none;
  border-radius: 30px;
  padding: 10px 20px;
  font-size: 16px;
}

.summary-section .btn-primary:hover {
  background-color: #45a049;
}
</style>
