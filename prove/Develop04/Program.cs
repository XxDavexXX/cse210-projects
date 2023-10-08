using System;
using System.Threading;

// Base class for all activities
public class Activity
{
    public string Name; // Name of the activity
    public string Description; // Description of the activity
    public int Duration; // Duration of the activity in seconds

    // Constructor for the Activity class
    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    // Simulates the start of an activity
    public virtual void Start()
    {
        // Displays a start message
        Console.WriteLine($"Starting {Name} activity...");
        Thread.Sleep(2000); // Simulated 2-second delay
    }

    // Simulates the end of an activity
    public virtual void End()
    {
        // Displays an end message
        Console.WriteLine($"Ending {Name} activity...");
        Thread.Sleep(2000); // Simulated 2-second delay
    }
}

// Breathing Activity class
public class BreathingActivity : Activity
{
    // Constructor for BreathingActivity
    public BreathingActivity() : base("Breathing Activity", "Relax and focus on your breath.")
    {
    }

    // Overrides the Start method from the base class
    public override void Start()
    {
        base.Start(); // Calls the base class's Start method

        // Displays specific breathing instructions
        Console.WriteLine("Inhale...");
        Thread.Sleep(Duration * 1000); // Simulated delay based on user-specified duration
        Console.WriteLine("Exhale...");
        Thread.Sleep(Duration * 1000); // Simulated delay based on user-specified duration
        Console.WriteLine("Inhale...");
        Thread.Sleep(Duration * 1000);
        Console.WriteLine("Exhale...");
        Thread.Sleep(Duration * 1000);
    }
}

// Reflection Activity class
public class ReflectionActivity : Activity
{
    private string[] ReflectionMessages = {
        "What personal achievement am I most proud of in my life so far, and why?",
        "What has been the most valuable lesson I've learned from a challenging experience?",
        "When was the last time I truly stepped out of my comfort zone, and what did I learn from that experience?",
        "What qualities or skills do I possess that I often underestimate but are actually valuable?",
        "When was the last time I did something selfless for someone else, and how did it make me feel?",
        "What dream or goal have I put off for a long time, and what steps can I take now to start working on it?"
    };

    // Constructor for ReflectionActivity
    public ReflectionActivity() : base("Reflection Activity", "Reflect on moments of strength and resilience.")
    {
    }

    // Overrides the Start method from the base class
    public override void Start()
    {
        base.Start(); // Calls the base class's Start method

        Random rand = new Random(); // Initializes a random number generator
        string message = ReflectionMessages[rand.Next(ReflectionMessages.Length)]; // Gets a random reflection message
        Console.WriteLine(message); // Displays the reflection message

        foreach (string question in GetRandomQuestions()) // Iterates over reflection questions
        {
            Console.WriteLine(question); // Displays a reflection question
            Thread.Sleep(2000); // Simulated 2-second delay
        }
    }

    // Gets random reflection questions
    private string[] GetRandomQuestions()
    {
        return new string[]
        {
            "Why was this experience meaningful to you?",
            "Had you ever done something like this before?",
            "Who are the people you have helped this week?",
            "When have you felt the Holy Spirit this month?",
            "Who are some of your personal heroes?"
        };
    }
}

// Listing Activity class
public class ListingActivity : Activity
{
    private string[] ListingMessages = {
        "Who are the people you appreciate?",
        "What are your personal strengths?",
        "Who are the people you have helped this week?",
        "When have you felt the Holy Spirit this month?",
        "Who are some of your personal heroes?"
    };

    // Constructor for ListingActivity
    public ListingActivity() : base("Listing Activity", "List as many positive things as you can.")
    {
    }

    // Overrides the Start method from the base class
    public override void Start()
    {
        base.Start(); // Calls the base class's Start method

        Random rand = new Random(); // Initializes a random number generator
        string message = ListingMessages[rand.Next(ListingMessages.Length)]; // Gets a random listing message
        Console.WriteLine(message); // Displays the listing message

        for (int i = 1; i <= Duration; i++) // Iterates from 1 to the user-specified duration
        {
            Console.WriteLine($"Item {i}"); // Displays a list item
            Thread.Sleep(2000); // Simulated 2-second delay
        }

        Console.WriteLine($"You listed {Duration} items."); // Displays the number of items listed
    }
}

// Main program class
public class Program
{
    // Entry point of the program
    public static void Main()
    {
        Console.WriteLine("Welcome to Mindfulness App!"); // Displays a welcome message

        Activity[] activities = {
            new BreathingActivity(), // Creates an instance of BreathingActivity
            new ReflectionActivity(), // Creates an instance of ReflectionActivity
            new ListingActivity() // Creates an instance of ListingActivity
        };

        foreach (Activity activity in activities) // Iterates over the activities
        {
            Console.WriteLine($"Selecting {activity.Name}"); // Displays a message for activity selection
            activity.Duration = GetDuration(); // Gets the duration of the activity from the user
            activity.Start(); // Starts the activity
            activity.End(); // Ends the activity
        }
    }

    // Gets the duration of the activity from the user
    public static int GetDuration()
    {
        Console.Write("Enter duration in seconds: ");
        return int.Parse(Console.ReadLine());
    }
}
