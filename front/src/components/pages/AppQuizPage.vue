<template>
    <div class="page container addQuizPageContainer">  
        <div class="row">
            <div class="col-12 header">
                <h2>DODAJ QUIZ</h2>
            </div>
        </div>
        <div class="row">
            <form @submit.prevent="submitQuiz">
                <div class="row">
                    <div class="form-group col-12 col-md-4">
                        <label for="quizTitle">Nazwa quizu</label>
                        <input type="text" class="form-control" v-model="quiz.title" id="quizTitle" aria-describedby="quizTitleHelp" placeholder="Wpisz nazwę quizu">
                        <small id="quizTitleHelp" class="form-text text-muted">Nazwa quizu powinna być krótka i zwięzła.</small>
                    </div>

                    <div class="form-group col-12 col-md-4">
                        <label for="quizCategory">Kategoria</label>
                        <select v-model="quiz.category" class="form-control">
                            <option>Matematyka</option>
                            <option>Polski</option>
                            <option>Angielski</option>
                            <option>Geografia</option>
                        </select>
                    </div>

                    <div class="form-group col-12 col-md-4">
                        <label for="quizPoints">Nagroda punktowa</label>
                        <input type="number" class="form-control" v-model="quiz.pointRewards" id="quizPoints" placeholder="Podaj liczbę punktów za quiz">
                    </div>

                    <div class="form-group col-12">
                        <label for="quizDescription">Opis quizu</label>
                        <textarea class="form-control" v-model="quiz.description" id="quizDescription" placeholder="Wpisz opis quizu"></textarea>
                    </div>
                </div>

                <div v-for="(question, index) in questions" :key="index" class="mt-4 question-container">
                    <h5>Pytanie {{ index + 1 }}</h5>
                    
                    <div class="form-group">
                        <label for="questionText">Zadaj pytanie:</label>
                        <input type="text" class="form-control" v-model="question.text" :id="'questionText' + index" placeholder="Wpisz treść pytania">
                    </div>

                    <div class="row answer-row">
                        <div class="col-md-6 form-group">
                            <label for="correctAnswer">Odpowiedź 1 (Poprawna):</label>
                            <input type="text" class="form-control" v-model="question.correctAnswer" :id="'correctAnswer' + index" placeholder="Wpisz poprawną odpowiedź">
                        </div>
                        <div class="col-md-6 form-group">
                            <label for="wrongAnswer1">Odpowiedź 3 (Niepoprawna):</label>
                            <input type="text" class="form-control" v-model="question.wrongAnswers[0]" :id="'wrongAnswer1' + index" placeholder="Wpisz niepoprawną odpowiedź 1">
                        </div>
                    </div>

                    <div class="row answer-row">
                        <div class="col-md-6 form-group">
                            <label for="wrongAnswer2">Odpowiedź 2 (Niepoprawna):</label>
                            <input type="text" class="form-control" v-model="question.wrongAnswers[1]" :id="'wrongAnswer2' + index" placeholder="Wpisz niepoprawną odpowiedź 2">
                        </div>
                        <div class="col-md-6 form-group">
                            <label for="wrongAnswer3">Odpowiedź 4 (Niepoprawna):</label>
                            <input type="text" class="form-control" v-model="question.wrongAnswers[2]" :id="'wrongAnswer3' + index" placeholder="Wpisz niepoprawną odpowiedź 3">
                        </div>
                    </div>

                    <button type="button" class="btn remove-btn" @click="removeQuestion(index)">Usuń pytanie</button>
                </div>

                <button type="button" class="btn add-btn" @click="addQuestion">DODAJ KOLEJNE PYTANIE</button>

                <button type="submit" class="btn btn-primary submit-btn mt-4">Zapisz quiz</button>
            </form>
        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default {
   name: "AppQuizPage",
   data() {
       return {
           quiz: {
               title: '',
               description: '',
               category: '',
               pointRewards: 0
           },
           questions: [
               {
                   text: '',
                   correctAnswer: '',
                   wrongAnswers: ['', '', '']
               }
           ]
       };
   },
   methods: {
       addQuestion() {
           this.questions.push({
               text: '',
               correctAnswer: '',
               wrongAnswers: ['', '', '']
           });
       },
       removeQuestion(index) {
           this.questions.splice(index, 1);
       },
       async submitQuiz() {
           try {
               const formattedData = {
                   quiz: {
                       title: this.quiz.title,
                       description: this.quiz.description,
                       category: this.quiz.category,
                       pointRewards: this.quiz.pointRewards
                   },
                   questions: this.questions.map(question => ({
                       questionText: question.text,
                       answers: [
                           { answerText: question.correctAnswer, isCorrect: true },
                           ...question.wrongAnswers.map(answer => ({ answerText: answer, isCorrect: false }))
                       ]
                   }))
               };

               const response = await axios.post('http://localhost:5080/Quiz/PostQuiz', formattedData);
               console.log('Quiz zapisany!', response.data);
               alert('Quiz został pomyślnie zapisany!');
           } catch (error) {
               console.error('Błąd podczas zapisywania quizu:', error);
               alert('Wystąpił problem podczas zapisywania quizu.');
           }
       }
   }
}
</script>

<style scoped>
.addQuizPageContainer {
    min-height: 100vh;
    padding-top: 50px;
    color: white;
}

.header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    color: #ffffff;
    font-weight: bold;
    font-size: 2rem;
}

.circle {
    width: 50px;
    height: 50px;
    background-color: #a5f5a5;
    border-radius: 50%;
}

.form-group {
    margin-bottom: 20px;
}

.form-control {
    background-color: #e7f6e7;
    border: none;
    border-radius: 10px;
    padding: 10px;
    font-size: 1rem;
    color: #1b1b2f;
}

.answer-row {
    display: flex;
    justify-content: space-between;
}

.answer-row .form-group {
    width: 48%;
}

.add-btn, .submit-btn, .remove-btn {
    background-color: #a5f5a5;
    color: #1b1b2f;
    border: none;
    padding: 10px 20px;
    border-radius: 30px;
    font-size: 1.2rem;
    font-weight: bold;
    display: block;
    margin: 20px auto;
    width: 100%;
    max-width: 400px;
    text-align: center;
    transition: background-color 0.3s ease;
}

.add-btn:hover, .submit-btn:hover, .remove-btn:hover {
    background-color: #88e088;
}
</style>
