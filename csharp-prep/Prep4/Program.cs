using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished: \n");

        Console.WriteLine("Enter number: \n");

        string number = Console.ReadLine();

        int number_int = int.Parse(number);

        numbers.Add(number_int);

        while (number_int != 0)
        {
            Console.WriteLine("\nEnter number: \n");

            number = Console.ReadLine();

            number_int = int.Parse(number);

            numbers.Add(number_int);
        }

        int sum = 0;
        int cont = 0;

        foreach (int i in numbers)
        {
            sum = sum + i;
            if (i != 0) { cont++; }
        }

        float average = sum / cont;
        int maxNumber = numbers[0];
        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] > maxNumber)
            {
                maxNumber = numbers[i];
            }
        }

        int smallestPositiveNumber = int.MaxValue;
        foreach (int number1 in numbers)
        {
            if (number1 > 0 && number1 < smallestPositiveNumber)
            {
                smallestPositiveNumber = number1;
            }
        }

        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}\n");
        Console.WriteLine($"The average is: {average}\n");
        Console.WriteLine($"The largest number is: {maxNumber}\n");
        Console.WriteLine($"The smallest positive number is:{smallestPositiveNumber}\n");
        foreach (int number2 in numbers)
        {
            Console.WriteLine(number2);
        }
    }
}
