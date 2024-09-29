<template>
  <div class="blockOfSomething">
    <div v-if="!quizStarted && !quizFinished" class="quiz-landing">
      <h2>{{ quiz.title }}</h2>
      <p>{{ quiz.description }}</p>
      <button @click="startQuiz">Rozpocznij quiz</button>
    </div>

    <!-- Quiz question screen -->
    <div v-if="quizStarted && !quizFinished" class="quiz-content">
      <h2>{{ quiz.title }}</h2>
      <p>Pytanie: {{ currentQuestion?.questionText }}</p>

      <!-- Sekcja odpowiedzi -->
      <div class="answerButtons" v-if="shuffledAnswers.length && !answered">
        <button v-for="(answer, index) in shuffledAnswers" :key="index" @click="selectAnswer(answer)">
          {{ answer.answerText }}
        </button>
      </div>

      <!-- Sekcja wyjaśnień -->
      <div v-else>
        <p><strong>{{ isCorrect ? 'Poprawna odpowiedź!' : 'Niepoprawna odpowiedź.' }}</strong></p>
        <p>Wyjaśnienie: {{ explanation }}</p>
        <button @click="nextQuestion">{{ currentQuestionIndex + 1 < quiz.questionsIds.length ? 'Następne pytanie' : 'Zakończ quiz' }}</button>
      </div>
    </div>

    <!-- Ekran końcowy -->
    <div v-if="quizFinished" class="summary-section">
      <h3>Quiz zakończony!</h3>
      <p>Zdobyłeś {{ score }} na {{ quiz.questionsIds.length }} punktów.</p>
      <button @click="restartQuiz">Rozpocznij ponownie</button>
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
        questionsIds: []
      },
      currentQuestionIndex: 0,
      currentQuestion: null,
      shuffledAnswers: [],
      answered: false,
      isCorrect: false,
      score: 0,
      quizStarted: false,
      quizFinished: false,
      loading: true,
      error: false,
      explanation: '', // Nowe pole dla wyjaśnienia
    };
  },
  created() {
    this.fetchQuizData();
  },
  methods: {
    async fetchQuizData() {
      try {
        const quizResponse = await axios.get('http://localhost:5080/Quiz/GetSingleQuiz', {
          params: { quizId: this.quizId },
        });
        this.quiz = quizResponse.data;
        await this.loadQuestion();
      } catch (error) {
        console.error('Błąd podczas pobierania danych quizu:', error);
        this.error = true;
      } finally {
        this.loading = false;
      }
    },
    async loadQuestion() {
      const questionId = this.quiz.questionsIds[this.currentQuestionIndex];
      if (!questionId) return;

      try {
        const questionResponse = await axios.get('http://localhost:5080/Quiz/GetQuestion', {
          params: { questionId },
        });
        this.currentQuestion = questionResponse.data;

        const answersResponse = await axios.get('http://localhost:5080/Quiz/GetAnswers', {
          params: { questionId },
        });
        this.shuffledAnswers = answersResponse.data.sort(() => Math.random() - 0.5);
      } catch (error) {
        console.error('Błąd podczas pobierania pytania lub odpowiedzi:', error);
      }
    },
    async selectAnswer(selectedAnswer) {
      this.answered = true;
      this.isCorrect = selectedAnswer.isCorrect;
      if (this.isCorrect) this.score++;

      // Pobierz losowe wyjaśnienie (zakładamy losowe API do wyjaśnienia)
      try {
        const questionId = this.quiz.questionsIds[this.currentQuestionIndex]; // Pobranie id pytania
        const explanationResponse = await axios.get('http://localhost:5080/Quiz/GetAIAnswer', {
          params: { questionId },
        });
        this.explanation = explanationResponse.data; // Losowe wyjaśnienie
      } catch (error) {
        console.error('Błąd podczas pobierania wyjaśnienia:', error);
        this.explanation = 'Nie udało się pobrać wyjaśnienia.';
      }
    },
    async nextQuestion() {
      this.answered = false;
      this.currentQuestionIndex++;
      if (this.currentQuestionIndex < this.quiz.questionsIds.length) {
        await this.loadQuestion();
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
      this.explanation = '';
    },
    startQuiz() {
      this.quizStarted = true;
      this.loadQuestion();
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
  background-color: #1b1b2f;
  padding: 40px;
  border-radius: 15px;
  color:white;
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

.blockOfSomething{
  position:absolute;
  left:50%;
  top:50%;
  transform:translate(-50%,-50%);
  width:500px;
  height:300px;
  display: flex;
  flex-direction: column;
}

.answerButtons{
  display: flex;
  flex-direction: row;
  justify-content: space-around;
}

.answerButtons button{
  width:20%;
  border-radius:5px;
}
</style>
