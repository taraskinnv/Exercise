using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Survey.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Survey
{
    public class Repository : IRepository
    {
        private readonly string connectionString;
        public Repository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("MyConnectionString");
        }
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = null;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                users = connection.Query<User>("select * from Users").ToList();
            }

            return users;
        }
        public string GetUser(int id)
        {
            //string user = String.Empty;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var user = connection.Query<string>($"select Users.email from Users where {id}=Users.id").First();
                return user;
            }


        }

        public IEnumerable<string> GetQuestions()
        {
            IEnumerable<string> questions = null;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                questions = connection.Query<string>("select Question.question from Question").ToList();
            }

            return questions;
        }

        public IEnumerable<string> GetAnswersSEnumerable(string question)
        {
            IEnumerable<string> answers = null;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                answers = connection.Query<string>("select Answer_options.answer from Answer_options").ToList();
            }

            return answers;
        }


        public bool? SaveQuestionAndAnswers(Poll poll)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var sqlQuery = "INSERT INTO Question (question, id_Users) VALUES(@question, @id_Users)";
                    connection.Execute(sqlQuery, new { question = poll.Question, id_Users = 1 });
                    var sqlId = $"SELECT Question.id from Question where Question.question = {poll.Question}";
                    int questionId = connection.Query<int>(sqlQuery).FirstOrDefault();

                    foreach (var pollAnswer in poll.Answers)
                    {
                        var addAnswer = $"INSERT INTO Answer_options (answer, id_Question) VALUES(@question, @id_Question)";
                        connection.Execute(addAnswer, new { answer = pollAnswer, id_Question = questionId });
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public IEnumerable<Poll> GetQuestionAndAnswers()
        {
            List<Poll> polls = new List<Poll>();
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var sqlGetQuestions = GetQuestions();



                foreach (var question in sqlGetQuestions)
                {
                    var sqlAnswers = Answers(GetAnswersSEnumerable(question));

                    polls.Add(new Poll() {Question =  question, Answers = sqlAnswers as List<Answer>});
                }

                return polls;
            }
        }

        public IEnumerable<Answer> Answers(IEnumerable<string> enumerable)
        {
            List<Answer> answers = new List<Answer>();
            for (int i = 0; i < enumerable.Count(); i++)
            {
                answers.Add(new Answer() { answer = ((List<string>)enumerable)[i] });
            }

            return answers;
        }
    }
}
