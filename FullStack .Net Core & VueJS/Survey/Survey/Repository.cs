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
    }
}
