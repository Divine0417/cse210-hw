// ChecklistGoal.cs
class ChecklistGoal : Goal
{
    public int _timesCompleted;
    public int _targetCount;
    public int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _targetCount = target;
        _bonus = bonus;
        _timesCompleted = 0;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
        int totalPoints = _points;
        if (_timesCompleted == _targetCount)
        {
            totalPoints += _bonus;
            Console.WriteLine($"Goal completed! You earned a bonus of {_bonus} points!");
        }
        Console.WriteLine($"You earned {totalPoints} points!");
    }

    public override bool IsComplete() => _timesCompleted >= _targetCount;

    public override string GetDetailsString() => $"[{(_timesCompleted >= _targetCount ? "X" : " ")}] {_shortName} ({_description}) -- Completed {_timesCompleted}/{_targetCount}";

    public override string GetStringRepresentation() => $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_bonus}|{_targetCount}|{_timesCompleted}";
}