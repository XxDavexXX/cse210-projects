using System;
using System.Collections.Generic;

public class Goal
{
    public string name;
    public int value;

    public Goal(string name, int value)
    {
        this.name = name;
        this.value = value;
    }

    public virtual void Complete()
    {
        Console.WriteLine($"You have completed the goal: {name}. You earned {value} points.");
    }

    public string Name
    {
        get { return name; }
    }

    public int Value
    {
        get { return value; }
    }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value)
    {
    }

    public override void Complete()
    {
        base.Complete();
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value)
    {
    }

    public override void Complete()
    {
        base.Complete();
    }
}

public class ChecklistGoal : Goal
{
    private int desiredCount;
    private int completed;

    public ChecklistGoal(string name, int value, int desiredCount) : base(name, value)
    {
        this.desiredCount = desiredCount;
    }

    public override void Complete()
    {
        completed++;

        if (completed >= desiredCount)
        {
            Console.WriteLine($"You have completed the checklist goal {name}! You earned a bonus of {value} points.");
        }
        else
        {
            base.Complete();
        }
    }

    public string Status
    {
        get { return $"Completed {completed}/{desiredCount} times"; }
    }
}

public class ProgressiveGoal : Goal
{
    private int currentProgress;
    private int targetProgress;

    public ProgressiveGoal(string name, int value, int targetProgress) : base(name, value)
    {
        this.currentProgress = 0;
        this.targetProgress = targetProgress;
    }

    public void MakeProgress(int amount)
    {
        currentProgress += amount;

        if (currentProgress >= targetProgress)
        {
            Complete();
            currentProgress = 0; // Reset progress
        }
    }

    public override void Complete()
    {
        Console.WriteLine($"You have made enough progress on the goal: {name}. You earned {value} points.");
    }

    public string ProgressStatus
    {
        get { return $"Current progress: {currentProgress}/{targetProgress}"; }
    }
}

public class User
{
    private int score;
    private List<Goal> goals = new List<Goal>();

    public int Score
    {
        get { return score; }
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RegisterEvent(Goal goal)
    {
        goal.Complete();
        score += goal.Value;
    }

    public void MakeProgressInProgressiveGoal(ProgressiveGoal goal, int amount)
    {
        goal.MakeProgress(amount);
        score += goal.Value;
    }

    public void ShowGoals()
    {
        foreach (var goal in goals)
        {
            if (goal is ChecklistGoal)
            {
                var checklistGoal = (ChecklistGoal)goal;
                Console.WriteLine($"{goal.Name}: {checklistGoal.Status}");
            }
            else if (goal is ProgressiveGoal)
            {
                var progressiveGoal = (ProgressiveGoal)goal;
                Console.WriteLine($"{goal.Name}: {progressiveGoal.ProgressStatus}");
            }
            else
            {
                Console.WriteLine($"{goal.Name}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        SimpleGoal marathon = new SimpleGoal("Run a marathon", 1000);
        EternalGoal readScriptures = new EternalGoal("Read scriptures", 100);
        ChecklistGoal attendTemple = new ChecklistGoal("Attend the temple", 50, 10);
        ProgressiveGoal workOnProject = new ProgressiveGoal("Work on the project", 200, 5);
        ProgressiveGoal eatHealthy = new ProgressiveGoal("Eat healthy", 150, 10);

        User user = new User();
        user.AddGoal(marathon);
        user.AddGoal(readScriptures);
        user.AddGoal(attendTemple);
        user.AddGoal(workOnProject);
        user.AddGoal(eatHealthy);

        user.RegisterEvent(marathon);
        user.RegisterEvent(readScriptures);
        user.RegisterEvent(attendTemple);
        user.RegisterEvent(attendTemple);
        user.RegisterEvent(attendTemple);
        user.RegisterEvent(attendTemple);
        user.RegisterEvent(attendTemple);
        user.RegisterEvent(attendTemple);
        user.RegisterEvent(attendTemple);
        user.RegisterEvent(attendTemple);
        user.RegisterEvent(attendTemple);
        user.RegisterEvent(attendTemple);

        user.MakeProgressInProgressiveGoal(workOnProject, 2);
        user.MakeProgressInProgressiveGoal(eatHealthy, 3);

        user.ShowGoals();
        Console.WriteLine($"Total score: {user.Score}");
    }
}



// I made a program called "Eternal Quest" that helps you track different types of goals. It's like a game where you earn points for completing goals.

// Here's what it does:

// Simple Goals: You can set simple goals like "Run a marathon" and when you complete them, you get points. For example, running a marathon gives you 1000 points.

// Eternal Goals: These are goals that you can do over and over again, like "Read scriptures". Every time you do it, you get points. You'll get 100 points each time.

// Checklist Goals: These are goals where you have to do something a certain number of times to complete it. For example, if you set a goal to "Attend the temple" 10 times, you'll get 50 points each time you go. When you reach 10 times, you'll get a bonus of 500 points.

// Progressive Goals: You can also set goals where you need to make progress towards something big, like working on a project. When you make enough progress, you get points.

// Negative Goals (optional): If you want, you can set goals where you lose points for bad habits.

// See Your Score: You can check how many points you have.

// Add Your Own Goals: You can create new goals of any type.

// Track Your Achievements: You can mark when you've completed a goal and get points for it.

// See Your Goal List: You can see a list of all your goals and know if they're completed or not.

// Save and Load: You can save your goals and scores, and load them later.

