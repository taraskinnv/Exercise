using System;
using System.Collections.Generic;
using System.Text;

namespace exercise_5
{
    class User
    {
        private String login;
        private String lastName;
        private Int32 age;
        private readonly DateTime createUser;

        public string Login { get => login; set => login = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Age
        {
            get => age; set
            {
                if (value <= 0)
                {
                    throw new Exception();
                }
                age = value;
            }
        }

        public DateTime CreateUser
        {
            get => createUser;

        }

        public User(String login, String lastName, Int32 age)
        {
            Login = login;
            LastName = lastName;
            Age = age;
            createUser = DateTime.Now;
        }

    }
}
