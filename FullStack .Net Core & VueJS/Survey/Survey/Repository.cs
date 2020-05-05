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


        public Int32? SaveQuestion( Poll poll)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var sqlQuery ="INSERT INTO Question (question, id_Users) VALUES(@question, @id_Users)";
                connection.Execute(sqlQuery,new { question = poll.Question, id_Users = 1 });
                var sqlId = $"SELECT Question.id from Question where Question.question = {poll.Question}";
                int? questionId = connection.Query<int>(sqlQuery).FirstOrDefault();
                return questionId;
            }
        }

        public Int32? SaveAnswer(Poll poll)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                return null;
            }
        }
    }
}
