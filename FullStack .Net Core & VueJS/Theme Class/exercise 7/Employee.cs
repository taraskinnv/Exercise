using System;
using System.Collections.Generic;
using System.Text;

namespace exercise_7
{
    enum Position
    {
        worker,
        engineer
    }
    class Employee
    {
        private String name;
        private String surname;

        private Int32 experienceYears;
        private Position position;
        private Double salary;


        public Employee(String name, String surname, Int32 experienceYears, Position position, Double salary)
        {
            this.name = name;
            this.surname = surname;
            this.experienceYears = experienceYears;
            this.position = position;
            this.salary = salary;
        }

        public string Name => name;

        public string Surname => surname;

        public int ExperienceYears => experienceYears;

        public Position GetPosition => position;

        public double Salary => salary;




        public Double TaxLevy()
        {
            if (ExperienceYears>15 && GetPosition == Position.worker)
            {
                return 20.5;
            }
            else if(ExperienceYears < 15 && GetPosition == Position.worker)
            {
                return 22;
            }
            else if(ExperienceYears > 15 && GetPosition == Position.engineer)
            {
                return 15;
            }
            else
            {
                return 22;
            }
        }

    }
}
