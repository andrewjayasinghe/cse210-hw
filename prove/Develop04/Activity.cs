using System;
using System.Threading;

public class Activity
{
    protected int _DurationInSeconds;
    protected DateTime _startTime;
    protected DateTime _endTime;
    protected string _activityType;
    protected string _activityDescription;

    protected List<string> _animationStrings;
    public Activity(int duration)
    {
        _DurationInSeconds = duration;
        _animationStrings = new List<string>();
    }

    public void AddAnimation(string item)
    {
        
        _animationStrings.Add(item);

    }

    public List<string> GetAnimation()
    {
        return _animationStrings;
    }
    public void SetDuration(int duration)
    {
        _DurationInSeconds = duration;
    }
    public void StartActivity()
    {
        Start();
        End();
    }

    protected virtual void Start()
    {
        
    }

    public void Ready(int value)
    {
        AddAnimation("|");
        AddAnimation("/");
        AddAnimation("-");
        AddAnimation("\\");
        AddAnimation("|");
        AddAnimation("/");
        AddAnimation("-");
        AddAnimation("\\");

        List<string> allAnimations = GetAnimation();
        
        _startTime = DateTime.Now;
      _endTime = _startTime.AddSeconds(value);

        int j = 0;

        while (DateTime.Now < _endTime)
        {
            string s = allAnimations[j];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            j++;
        }

    }

    protected virtual void End()
    {
        Console.WriteLine("\nWell Done!");
        Ready(3);
        Console.WriteLine("\nYou have completed the activity!");
        Ready(3);

    }

    public void SetActivity(string activity)
    {
        _activityType = activity;
    }

    public void SetDescription(string description)
    {
        _activityDescription = description;
    }
    public string ShowActivity()
    {
        return $"Welcome to the {_activityType} Activity.\n\n";
    }

    public string ShowDescription()
    {
        return $"{_activityDescription}\n";
    }

}


























