using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();

        int number = PromptUserNumber();
        int squaredNumber = SquareNumber(number);

        DisplayResult(name, number, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!\n");
    }

    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name.\n");

        string name2 = Console.ReadLine();

        Console.WriteLine($"\nHello {name2}, nice to meet you !!!\n");
        return name2;
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number: \n");
        string numberString = Console.ReadLine();
        int number = Convert.ToInt32(numberString);
        Console.WriteLine($"\nYour favorite number is: {number}\n");
        return number;
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
