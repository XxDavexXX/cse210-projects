using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!\n");

        Console.WriteLine("------------ START HERE ------------\n");

        Console.WriteLine("Enter your final course grade: \n");

        string grade = Console.ReadLine();

        int grade_int = int.Parse(grade);

        string letter_result;

        if (grade_int >= 90)
        {
            letter_result = "A";
        }
        else if (grade_int >= 80)
        {
            letter_result = "B";
        }
        else if (grade_int >= 70)
        {
            letter_result = "C";
        }
        else if (grade_int >= 60)
        {
            letter_result = "D";
        }
        else if (grade_int < 60)
        {
            letter_result = "F";
        }
        else
        {
            Console.WriteLine("\nInvalid data");
            letter_result = "Unknown";
        }

        int grade_remainder = grade_int % 10;
        string grade_sign;
        if (grade_remainder >= 7 && letter_result == "A")
        {
            grade_sign = "";
        }
        else if (grade_remainder < 7 && letter_result == "A")
        {
            grade_sign = "-";
        }
        else if (letter_result == "F")
        {
            grade_sign = "";
        }
        else if (grade_remainder >= 7 && letter_result == "B")
        {
            grade_sign = "+";
        }
        else if (grade_remainder < 7 && letter_result == "B")
        {
            grade_sign = "-";
        }
        else if (grade_remainder >= 7 && letter_result == "C")
        {
            grade_sign = "+";
        }
        else if (grade_remainder < 7 && letter_result == "C")
        {
            grade_sign = "-";
        }
        else if (grade_remainder >= 7 && letter_result == "D")
        {
            grade_sign = "+";
        }
        else if (grade_remainder < 7 && letter_result == "D")
        {
            grade_sign = "-";
        }
        else
        {
            grade_sign = "";
        }

        Console.WriteLine($"\nYour letter grade is: {letter_result}{grade_sign}");

        if (grade_int >= 70)
        {
            Console.WriteLine("\nCongratulations, you passed! Great job!");
        }
        else
        {
            Console.WriteLine("\nUnfortunately, you did not pass. Better luck next time!");
        }

    }
}
