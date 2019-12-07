using System;

namespace exercise_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Nick", "Taraskin",13,Position.engineer, 5000);
            Console.WriteLine($"name: { employee.Name}, surname: { employee.Surname}, position: { employee.GetPosition}, salary: { employee.Salary}, tax levy: { employee.TaxLevy()}%");
        }
    }
}
