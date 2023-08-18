using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProgram
{
    internal class FileManager
    {
        private static string path = "./";
        private static string fileName = "cars.csv";
        public static void Save()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Menu.carsTableHeader.Replace("\t\t",",\t\t"));

            foreach (Car car in Menu.cars)
            {
                string carString = String.Format("{0},\t\t{1},\t\t{2},\t\t{3},\t\t{4}", car.year, car.make, car.model, car.color, car.hp);
                sb.AppendLine(carString);
            }
            File.WriteAllText(path + fileName, sb.ToString());
            Console.WriteLine(Menu.cars.Count() + " cars saved to file.");
        }

        public static void Load()
        {
            Console.Clear();
            string carsString = File.ReadAllText(path + fileName).Trim();

            string[] carsArray = carsString.Split(new char[] { '\n' });
            carsArray = carsArray.Skip(1).ToArray();

            foreach (string carString in carsArray)
            {
                Car car = new Car();
                string[] carArray = carString.Replace("\t","").Split(new char[] { ',' });
                car.year = carArray[0];
                car.make = carArray[1];
                car.model = carArray[2];
                car.color = carArray[3];
                car.hp = carArray[4];
                

                Menu.cars.Add(car);
            }

            Console.WriteLine(carsArray.Count() + " cars loaded from file.");
        }

        public bool SaveExists()
        {
            return File.Exists(path + fileName);
        }
    }
}
