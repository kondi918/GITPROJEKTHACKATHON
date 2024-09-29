using Api.Data;
using Api.Models.Requests;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Web;
using Api.Models.DTO;
using Api.Responses;

namespace Api.Services
{
    public class QuizService
    {
        private readonly DatabaseContext _databaseContext;

        public QuizService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        //Adding Quiz below
        private bool AreQuestionsCorrect(List<QuestionDTO> questions)
        {
            foreach (var question in questions)
            {
                if (string.IsNullOrWhiteSpace(question.QuestionText))
                {
                    return false;
                }
                if(question.Answers == null)
                {
                    return false;
                }
                if(question.Answers.Count <= 0)
                {
                    return false;
                }
                foreach (var answer in question.Answers)
                {
                    if(answer.IsCorrect == null || string.IsNullOrWhiteSpace(answer.AnswerText))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool IsQuizCorrect(QuizDTO quiz)
        {
            if(quiz.PointRewards <= 0)
            {
                return false;
            }
            if(string.IsNullOrWhiteSpace(quiz.Description) || string.IsNullOrWhiteSpace(quiz.Title) || string.IsNullOrWhiteSpace(quiz.Category))
            {
                return false;
            }
            return true;
        }
        private bool IsQuizDataCorrect(CreateQuizRequest quizToAdd)
        {
            if (quizToAdd == null)
            {
                return false;
            }
            if(quizToAdd.Questions == null || quizToAdd.Quiz == null)
            {
                return false;
            }
            if(quizToAdd.Questions.Count <= 0)
            {
                return false;
            }
            if(!AreQuestionsCorrect(quizToAdd.Questions))
            {
                return false;
            }
            if (!IsQuizCorrect(quizToAdd.Quiz))
            {
                return false;
            }
            return true;
        }
        private Quizes CreateNewQuiz(QuizDTO quiz)
        {
            Quizes newQuiz = new Quizes
            {
                Category = quiz.Category,
                Description = quiz.Description,
                Title = quiz.Title,
                PointRewards = quiz.PointRewards,
                CreatedAt = DateTime.Now
            };
            return newQuiz;      
        }
        private Questions CreateNewQuestion(QuestionDTO question, Quizes quiz)
        {
            Questions newQuestion = new Questions
            {
                QuestionText = question.QuestionText,
                CreatedAt = DateTime.Now,
                Quiz = quiz
            };
            return newQuestion;
        }
        private Answers CreateNewAnswer(AnswerDTO answer, Questions question)
        {
            Answers newAnswer = new Answers
            {
                AnswerText = answer.AnswerText,
                IsCorrect = answer.IsCorrect,
                Questions = question
            };
            return newAnswer;
        }
        public async Task<bool> AddQuiz(CreateQuizRequest quizToAdd)
        {
            try
            {
                if (!IsQuizDataCorrect(quizToAdd))
                {
                    return false;
                }
                using (var transaction = await _databaseContext.Database.BeginTransactionAsync())
                {
                    Quizes quiz = CreateNewQuiz(quizToAdd.Quiz);
                    _databaseContext.Quizes.Add(quiz);
                    await _databaseContext.SaveChangesAsync();
                    foreach (var question in quizToAdd.Questions) 
                    {
                        Questions newQuestion = CreateNewQuestion(question, quiz);
                        _databaseContext.Questions.Add(newQuestion);
                        await _databaseContext.SaveChangesAsync();
                        foreach(var answer in question.Answers)
                        {
                            Answers newAnswer = CreateNewAnswer(answer, newQuestion);
                            _databaseContext.Answers.Add(newAnswer);
                            await _databaseContext.SaveChangesAsync();
                        }
                    }
                    await _databaseContext.SaveChangesAsync(); // Zapis odpowiedzi
                    await transaction.CommitAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured during adding quiz to database. Description: " + ex.Message);
            }
        }

        //Getting every Quiz below
        public async Task<List<QuizDTO>> GetAllQuizes(string category)
        {
            try
            {
                var quizzes = await _databaseContext.Quizes.Where(q => q.Category == category).ToListAsync();
                List<QuizDTO> allQuizes = new List<QuizDTO>();
                foreach (var quiz in quizzes)
                {
                    allQuizes.Add(new QuizDTO
                    {
                        Category = quiz.Category,
                        Description = quiz.Description,
                        Title = quiz.Title,
                        PointRewards = quiz.PointRewards,
                        Id = quiz.Id
                    });
                }
                return allQuizes;

            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while getting all quizes: " + ex.Message);
            }
        }
        //Getting single Quiz below
        public async Task<SingleQuizResponse> GetSingleQuiz(int quizId)
        {
            try
            {
                if (quizId <= 0)
                {
                    throw new ArgumentException("QuizId musi być większy od zera.");
                }

                var quiz = await _databaseContext.Quizes.Include(q => q.Questions).FirstOrDefaultAsync(q => q.Id == quizId);

                if (quiz == null)
                {
                    throw new Exception("Nie znaleziono quizu dla podanego Id ani quizu domyślnego.");
                }

                SingleQuizResponse singleQuizResponse = new SingleQuizResponse
                {
                    Description = quiz.Description,
                    Title = quiz.Title,
                    Category = quiz.Category,
                    PointRewards = quiz.PointRewards,
                    questionsIds = quiz.Questions.Select(question => question.Id).ToList()
                };

                Console.WriteLine($"Quiz zwrócony: Id = {quiz.Id}, Liczba pytań = {quiz.Questions.Count}");

                return singleQuizResponse;
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił błąd podczas pobierania quizu: " + ex.Message, ex);
            }
        }
        //Getting single question below

        public async Task<QuestionDTO> GetSingleQuestion(int questionId)
        {
            try
            {
                if (questionId <= 0)
                {
                    throw new ArgumentException("QuizId musi być większy od zera.");
                }
                var question = await _databaseContext.Questions.Include(q => q.Answers).FirstOrDefaultAsync(q => q.Id == questionId);
                QuestionDTO foundQuestion = new QuestionDTO
                {
                    Id = question.Id,
                    QuestionText = question.QuestionText
                };
                return foundQuestion;
            }
            catch(Exception ex)
            {
                throw new Exception("Error occured while getting question: " + ex.Message);

            }
        }


        //Getting every answer below

        public async Task<List<AnswerDTO>> GetAnswers(int questionId)
        {
            try
            {
                var answers = await _databaseContext.Answers.Where(a => a.QuestionId == questionId).ToListAsync();
                List<AnswerDTO> answerList = new List<AnswerDTO>();
                foreach(var answer in answers)
                {
                    answerList.Add(new AnswerDTO
                    {
                        Id = answer.Id,
                        AnswerText = answer.AnswerText,
                        IsCorrect = answer.IsCorrect,
                    });
                }
                return answerList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while getting all quizes: " + ex.Message);
            }
        }
        public async Task<string> GetMessageFromAI(int questionId)
        {
            try
            {
                if (questionId <= 0)
                {
                    throw new ArgumentException("QuizId musi być większy od zera.");
                }
                var question = await _databaseContext.Questions.FirstOrDefaultAsync(q => q.Id == questionId);
                var answer = await _databaseContext.Answers.FirstOrDefaultAsync(a => a.QuestionId == questionId && a.IsCorrect);
                string AIQuestion = "Podaj bardzo krotko wyjasnienie, dlaczego poprawna odpowiedz na pytanie: " + question.QuestionText + " to: " + answer.AnswerText;
                return AIQuestion;
            }
            catch(Exception ex)
            {
                throw new Exception("Error occured while getting message from AI: " + ex.Message);

            }
        }

    }
}
