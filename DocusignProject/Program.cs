using System;


namespace DocusignProject
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Good morning! Enter in a command to get dressed, or quit to exit: ");
                string userInput = Console.ReadLine();

                if (userInput == "quit")
                {
                    break;
                }

                Person p = new Person(userInput);
                Console.WriteLine(p.ValidateData());
            }
            Console.WriteLine("done.");
        }
    }
}
