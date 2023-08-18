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
        //Creates a new Car List
        public static List<Car> cars = new List<Car>();

        public static string carsTableHeader = "year\t\tmake\t\tmodel\t\tcolor\t\thp";

        //Manages the main interaction logic. Provides the user with options to choose from to interact with the program
        public static void MainMenu()
        {
            //Clears the console, then lists the programs main options
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
            // Console.ReadLine resturns a string?, witch is a nullable string, and can break the code in some cases. But we're ignoring it for now.
            string option = Console.ReadLine();

            //Handles the user selection
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
                case "3":
                    FileManager.Save();
                    Console.WriteLine("Press any key to return to the Main Menu...");
                    Console.ReadKey(true);
                    MainMenu();
                    break;
                case "4":
                    FileManager.Load();
                    Console.WriteLine("Press any key to return to the Main Menu...");
                    Console.ReadKey(true);
                    MainMenu();
                    break;
                case "9":
                    Console.Clear();
                    System.Environment.Exit(0);
                    break;

                // If the 'option' var is not listed in the cases above, it falls back to this message
                default:
                    Console.Clear();
                    Console.WriteLine("Option '{0}' not found.", option);
                    Console.WriteLine("Press any key to return to the Main Menu...");
                    Console.ReadKey(true);
                    MainMenu();
                    break;

            }
        }


        //Handles the Add Car option in the Main Menu
        public static void AddCar()
        {
            Console.Clear();

            //Creates a new instance of the Car object that we are going to manipulate 
            Car car = new Car();

            //Prompts the user for the car's properties, then assings them to the 'car' object
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

            // Reaffirms the user about the info provided, and gives them the option to save to the memory the input, or to discard the data
            Console.WriteLine("You created a {0}, {1}hp {2} {3} {4}", car.color, car.hp, car.year, car.make, car.model);
            Console.WriteLine("");
            Console.WriteLine("You want to save this car? (Y/N)");

            // Checks if the answer is the charachter 'Y'.
            // Console.ReadKey() returns an object that needs to be converted to a string before checking for equality
            // ToUpper() is used here to make sure a lower case 'y' is converted to the upper case 'Y' before comparing
            if ("Y" == Console.ReadKey(true).KeyChar.ToString().ToUpper())
            {
                // Adds the newly created 'car' to the list 'cars'
                cars.Add(car);
                Console.WriteLine("Car added!");
            }
            else
            {
                // Tells the user the car was not saved.
                Console.WriteLine("Car not saved.");
            }
        }


        // Tries to list the cars on memory
        public static void ListCars()
        {
            Console.Clear();

            // Checks if there are any cars saved on the List 'cars' to avoid showing an empty list to the user.
            if (cars.Count > 0)
            {
                // The \t special char is a tab, used to format tables 
                Console.WriteLine("#\t\t" + carsTableHeader);

                // Writes a new line in the console for each new 'car' in the List 'cars'
                foreach (var car in cars)
                {
                    Console.WriteLine("{0}.\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}", cars.IndexOf(car) + 1, car.year, car.make, car.model, car.color, car.hp);
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
