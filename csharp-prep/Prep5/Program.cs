using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        PromptUserName();

        int number = PromptUserNumber();
        int squaredNumber = SquareNumber(number);

        DisplayResult(name, number, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!\n");
    }

    static void PromptUserName()
    {
        Console.WriteLine("Please enter your name.\n");

        string nombre Console.ReadLine();

        Console.WriteLine($"\nHello {nombre}, nice to meet you !!!\n");
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number: \n");
        string number = Console.ReadLine();
        int number_int = Console.ReadLine();
        Console.WriteLine($"\nYour favorite number is: {number_int}\n");
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int number, int squaredNumber)
    {
        Console.WriteLine($"Hi {name}, the square of {number} is {squaredNumber}.\n");
    }
}
