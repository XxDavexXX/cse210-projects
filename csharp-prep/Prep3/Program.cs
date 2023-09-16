using System;

class Program
{
    static void Main(string[] args)
    {

        Random random = new Random();

        string decision = "yes";

        while (decision == "yes")
        {
            int magic_number_int = random.Next(1, 101);

            Console.WriteLine("\nWhat is your guess?: \n");

            string guess_number = Console.ReadLine();

            int guess_number_int = int.Parse(guess_number);

            int count = 0;
            while (guess_number_int != magic_number_int)
            {
                if(magic_number_int > guess_number_int){
                    Console.WriteLine("\nHigher\n");
                }else if(magic_number_int < guess_number_int){
                    Console.WriteLine("\nLower\n");
                }else{
                    Console.WriteLine("\nPlease enter a valid number: \n");
                }

                Console.WriteLine("What is your guess?: \n");
                guess_number = Console.ReadLine();

                guess_number_int = int.Parse(guess_number);
                count++;
            }

            Console.WriteLine("\nYou guessed it! \n");
            Console.WriteLine($"The number of attempts played this round was: {count}! \n");

            Console.WriteLine("Do you want to play another round? \n");

            decision = Console.ReadLine();
        }  

        Console.WriteLine("Good bye! \n");
    }
}
