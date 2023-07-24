using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarProgram
{
    internal class Menu
    {

        static List<Car> cars = new List<Car>();

        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine(" --- Car Program ---");
            Console.WriteLine("");
            Console.WriteLine("Options");
            Console.WriteLine("1. Add new Car");
            Console.WriteLine("2. List cars");
            Console.WriteLine("3. Save list");
            Console.WriteLine("4. Load list");
            Console.WriteLine("9. Quit");
            Console.WriteLine("");
            Console.Write("Insert option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddCar();
                    Console.WriteLine("Press any key to return to the Main Menu...");
                    Console.ReadKey(true);
                    MainMenu();
                    break;
                case "2":
                    ListCars();
                    Console.WriteLine("Press any key to return to the Main Menu...");
                    Console.ReadKey(true);
                    MainMenu();
                    break;
                case "9":
                    Console.Clear();
                    System.Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Option '{0}' not found.", option);
                    Console.WriteLine("Press any key to return to the Main Menu...");
                    Console.ReadKey(true);
                    MainMenu();
                    break;

            }
        }

        public static void AddCar()
        {
            Console.Clear();

            Car car = new Car();

            Console.WriteLine("What is the car make?");
            car.make = Console.ReadLine();

            Console.WriteLine("What is the car model?");
            car.model = Console.ReadLine();

            Console.WriteLine("What is the car fabrication year?");
            car.year = Console.ReadLine();

            Console.WriteLine("What is the car color?");
            car.color = Console.ReadLine();

            Console.WriteLine("What is the car hp?");
            car.hp = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("You created a {0}, {1}hp {2} {3}", car.color, car.hp, car.make, car.model);
            Console.WriteLine("");
            Console.WriteLine("You want to save this car? (Y/N)");
            if ("Y" == Console.ReadKey(true).KeyChar.ToString().ToUpper())
            {
                cars.Add(car);
                Console.WriteLine("Car added!");
            }
            else
            {
                Console.WriteLine("Car not saved.");
            }
        }
        public static void ListCars()
        {
            Console.Clear();
            if (cars.Count > 0)
            {
                Console.WriteLine("#\tmake\tmodel\tcolor\thp");
                foreach (var car in cars)
                {
                    Console.WriteLine("{0}.\t{1}\t{2}\t{3}\t{4}", cars.IndexOf(car) + 1, car.make, car.model, car.color, car.hp);
                }
                Console.WriteLine("");
                Console.WriteLine("Found {0} cars in the list", cars.Count());
            }
            else
            {
                Console.WriteLine("The list of cars is empty");
            }


        }
    }
}
