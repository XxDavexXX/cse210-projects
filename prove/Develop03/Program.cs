using System;
using System.Collections.Generic;
using System.Linq;

// Represents a single word in the scripture text.
class Word
{
    public string Text { get; private set; } // Stores the word.
    public bool IsHidden { get; private set; } // Indicates if the word is hidden or not.

    // Constructor: Initializes a Word object with a given text.
    public Word(string text)
    {
        Text = text; // Set the 'Text' property.
        IsHidden = false; // By default, the word is not hidden.
    }

    // Method: Hide the word.
    public void Hide()
    {
        if (IsHidden)
        {
            return; // If the word is already hidden, do nothing.
        }

        IsHidden = true; // Set 'IsHidden' to true to indicate the word is now hidden.
    }
}

// Represents a scripture passage with a reference and text.
class Scripture
{
    public string Reference { get; private set; } // Stores the scripture reference.
    public string Text { get; private set; } // Stores the scripture text.
    public List<Word> Words { get; private set; } // Stores the list of Word objects.

    // Constructor: Initializes a Scripture object with a given reference and text.
    public Scripture(string reference, string text)
    {
        Reference = reference; // Set the 'Reference' property.
        Text = text; // Set the 'Text' property.
        Words = Text.Split(' ').Select(word => new Word(word)).ToList();
        // 'Words' is populated by creating Word objects for each word in the scripture text.
    }

    // Method: Hide a random word in the scripture text.
    public void HideRandomWord()
    {
        if (Words.Any(w => !w.IsHidden))
        {
            // If there are still unhidden words in the scripture text.
            Random random = new Random(); // Create a random number generator.
            int randomIndex = random.Next(0, Words.Count); // Generate a random index.
            
            while (Words[randomIndex].IsHidden)
            {
                randomIndex = random.Next(0, Words.Count);
                // Keep generating a new random index until an unhidden word is found.
            }

            Words[randomIndex].Hide(); // Hide the selected word.
        }
    }

    // Method: Count the number of hidden words in the scripture text.
    public int CountHiddenWords()
    {
        return Words.Count(w => w.IsHidden); // Count the hidden words using LINQ.
    }

    // Override the ToString() method to display the scripture text with hidden words.
    public override string ToString()
    {
        string result = "";

        foreach (var word in Words)
        {
            if (word.IsHidden)
            {
                result += new string('_', word.Text.Length) + " ";
            }
            else
            {
                result += word.Text + " ";
            }
        }

        return result.Trim(); // Return the formatted scripture text.
    }
}

// Entry point of the application.
class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            // Create a list of Scripture objects with different references and texts.
            new Scripture("John 3:16", "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life."),
            new Scripture("Genesis 1:1", "In the beginning, God created the heavens and the earth."),
            new Scripture("1 John 1:9", "If we confess our sins, he is faithful and just to forgive us our sins and to cleanse us from all unrighteousness."),
            new Scripture("Joshua 1:9", "Have I not commanded you? Be strong and courageous. Do not be frightened, and do not be dismayed, for the Lord your God is with you wherever you go."),
            new Scripture("John 3:16", "For God did not send his Son into the world to condemn the world, but in order that the world might be saved through him."),
            new Scripture("1 John 1:9", "But if we walk in the light, as he is in the light, we have fellowship with one another, and the blood of Jesus his Son cleanses us from all sin."),
            new Scripture("Isaiah 41:10", "Fear not, for I am with you; be not dismayed, for I am your God; I will strengthen you, I will help you, I will uphold you with my righteous right hand."),
            new Scripture("Romans 12:12", "Rejoice in hope, be patient in tribulation, be constant in prayer."),
            new Scripture("Psalms 34:18", "The Lord is near to the brokenhearted and saves the crushed in spirit."),
            new Scripture("Matthew 7:7", "Ask, and it will be given to you; seek, and you will find; knock, and it will be opened to you."),
            new Scripture("Matthew 18:20", "For where two or three are gathered in my name, there am I among them."),
            new Scripture("John 5:15", "And if we know that he hears us in whatever we ask, we know that we have the requests that we have asked of him."),
        };

        Random random = new Random(); // Create a random number generator.

        // Select a random scripture from the list to start the process.
        Scripture selectedScripture = scriptures[random.Next(0, scriptures.Count)];

        // Loop to interact with the user until all words are hidden or the user chooses to exit.
        while (selectedScripture.Words.Any(w => !w.IsHidden))
        {
            Console.Clear(); // Clear the console for a clean display.

            // Display the reference and the scripture text with hidden words.
            Console.WriteLine(selectedScripture.Reference);
            Console.WriteLine(selectedScripture.ToString());

            // Display the number of hidden words and the total number of words.
            Console.WriteLine($"Hidden words: {selectedScripture.CountHiddenWords()} of {selectedScripture.Words.Count}");

            // Prompt the user for input.
            Console.WriteLine("\nPress Enter to hide a word or type 'exit' to finish.");
            string input = Console.ReadLine(); // Read the user's input.

            if (input.ToLower() == "exit")
            {
                break; // If the user chooses to exit, break out of the loop.
            }

            selectedScripture.HideRandomWord(); // Hide a random word.

            if (selectedScripture.CountHiddenWords() == selectedScripture.Words.Count)
            {
                Console.WriteLine("All words are hidden!");
                break;
            }
        }
    }
}
