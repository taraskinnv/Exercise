using System;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Train[] trains = new Train[8];

            for (int i = 0; i < trains.Length; i++)
            {
                Console.Write($"Train number: ");
                Int32 tempTrainNumber = Int32.Parse(Console.ReadLine());

                Console.Write($"Destination: ");
                string tempDestination = Console.ReadLine();

                Console.Write($"Time of departure HOUR: ");
                Int32 hour = Int32.Parse(Console.ReadLine());
                Console.Write($"Time of departure MIN: ");
                Int32 min = Int32.Parse(Console.ReadLine());

                trains[i] = new Train(tempDestination, tempTrainNumber, new DateTime(2020, 01, 6, hour, min, 0));
                Console.Clear();
            }

            /*trains = new[]
            {
                new Train("Kiev", 80, new DateTime(2020, 01, 6, 10, 10, 0)),
                new Train("Dnipro", 79, new DateTime(2020, 01, 6, 10, 10, 0)),
                new Train("Lviv", 65, new DateTime(2020, 01, 6, 17, 50, 0)),
                new Train("Odessa", 30, new DateTime(2020, 01, 6, 23, 40, 0)),
                new Train("Rivno", 769, new DateTime(2020, 01, 6, 5, 29, 0)),
                new Train("Kiev", 80, new DateTime(2020, 01, 6, 12, 15, 0)),
                new Train("Dnipro", 79, new DateTime(2020, 01, 6, 8, 55, 0)),
                new Train("Dnipro", 79, new DateTime(2020, 01, 6, 16, 3, 0))
            };
            */

            Sort(trains);

            /*foreach (var train in trains)
            {
                    train.Show();
            }

            Console.WriteLine();*/

            Console.Write("Enter train number:");
            Int32 number = Int32.Parse(Console.ReadLine());
            Boolean b = true;
            Console.WriteLine("Train number:");
            foreach (var train in trains)
            {
                if (train.TrainNumber == number)
                {
                    train.Show();
                    b = false;
                }
            }

            if (b)
            {
                Console.WriteLine("Train number not found");
            }
        }

        static void Sort(Train[] trains)
        {
            Train temp;

            for (int i = 0; i < trains.Length - 1; i++)
            {
                for (int j = i + 1; j < trains.Length; j++)
                {
                    if (trains[i].TrainNumber > trains[j].TrainNumber)
                    {
                        temp = trains[i];
                        trains[i] = trains[j];
                        trains[j] = temp;
                    }
                }
            }
        }
    }

    struct Train
    {
        private String destination;
        private Int32 trainNumber;
        private DateTime timeOfDeparture;

        public Int32 TrainNumber
        {
            get { return this.trainNumber; }
        }
        public Train(String destination, Int32 trainNumber, DateTime timeOfDeparture)
        {
            this.destination = destination;
            this.trainNumber = trainNumber;
            this.timeOfDeparture = timeOfDeparture;
        }
        public void Show()
        {
            Console.WriteLine($"Train Number: {this.trainNumber}, Destination {this.destination}, time of departure {this.timeOfDeparture}");
        }
    }
}
