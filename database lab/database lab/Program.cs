namespace StudentDataBase
{
    internal class Program
    {
        public static int studentID = 0;
        public static string userinput = string.Empty;

        public static string[] studentNames = new string[4] { "Jerry", "Benson", "Eren", "Timothy" };
        public static string[] studentHometowns = new string[4] { "Dearborn", "Detroit", "New York", "Pheonix" };
        public static string[] studentFavoriteFoods = new string[4] { "Burger", "Brownie", "Pizza", "Soup" };


        static void Main(string[] args)
        {
            Prompt();
        }

        public static void Prompt()
        {
            Console.WriteLine($"Hello This the the student info database is there a student you would like info on?\nPlease enter a number 0 - {studentNames.Length - 1} ");
            userinput = Console.ReadLine();

            while (true)
            {
                if (!int.TryParse(userinput, out studentID))
                {
                    Console.WriteLine("Please enter a number and try again.");
                    userinput = Console.ReadLine();
                    continue;
                }

                else if (!InRange(studentID, 0, studentNames.Length - 1) && studentID != -1)
                {
                    Console.WriteLine($"Your number isn't in the current range. Please enter a number within the range: 0 - {studentNames.Length}.");
                    userinput = Console.ReadLine();
                    continue;
                }

                else
                {
                    OptionsScreen();
                    break;
                }
            }
        }
        public static void OptionsScreen()
        {
            Console.WriteLine($"You Chose {studentNames[studentID]}. Do you want to know {studentNames[studentID]}'s hometown or favorite food?");

            List<string> hometownWords = new List<string>();
            List<string> foodWords = new List<string>();

            hometownWords.AddRange(new List<string> { "HOME", "TOWN" });
            foodWords.AddRange(new List<string> { "FOOD", "FAVORITE" });

            while (true)
            {
                string selectedCategory = Console.ReadLine().ToUpper().Trim();

                if (hometownWords.Contains(selectedCategory))
                {
                    HomeTown(studentID);
                    break;
                }

                else if (foodWords.Contains(selectedCategory))
                {
                    Food(studentID);
                    break;
                }

                else
                {
                    Console.WriteLine($"{selectedCategory} is not a category. Please try again.\nEnter \"Home\" or \"Food\"");
                }
            }

            Console.WriteLine("\nWould you like to try again?\n" +
                "Enter \"Y\" to start again. " +
                "Enter \"N\" to exit. ");

            Continue();
        }

        public static void Continue()
        {
            string userContinue = Console.ReadLine().ToUpper();

            if (userContinue == "Y" || userContinue == "YES")
            {
                Console.WriteLine();
                Prompt();
            }

            else
            {
                Console.WriteLine("Bye!");
            }
        }

        public static void HomeTown(int index)
        {
            for (int i = 0; i < studentNames.Length; i++)
            {
                if (index == i)
                {
                    Console.WriteLine($"{studentNames[i]}'s hometown is {studentHometowns[i]}.");
                }
            }
        }

        public static void Food(int index)
        {
            for (int i = 0; i < studentNames.Length; i++)
            {
                if (index == i)
                {
                    Console.WriteLine($"{studentNames[i]}'s favorite food is {studentFavoriteFoods[i]}.");
                }
            }
        }

        public static bool InRange(int userNumber, int minRange, int maxRange)
        {
            return userNumber >= minRange && userNumber <= maxRange;
        }
    }
}