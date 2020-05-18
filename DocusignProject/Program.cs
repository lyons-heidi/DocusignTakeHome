using System;


namespace DocusignProject
{
    class Program
    {
        static void Main(string[] args)
        {

            Person p = new Person();

            while (true)
            {
                Console.WriteLine("Good morning! Enter in a command to get dressed, or quit to exit: ");
                p.RestartDay();
                string userInput = Console.ReadLine();

                if (userInput == "quit")
                {
                    break;
                }

                p.ParseInput(userInput);
                Console.WriteLine(p.ValidateData());
            }
            Console.WriteLine("done.");
        }
    }
}
