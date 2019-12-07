using System;

namespace exercise_5
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("qwerty", "taraskin", 33);

            Console.WriteLine($"User: Login = {user.Login}, last Name = {user.LastName}, age = {user.Age}, date create = {user.CreateUser}");
        }
    }
}
