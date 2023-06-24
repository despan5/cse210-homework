namespace Develope05;

public abstract class Goal
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; protected set; }

    public abstract void CreateGoal();
    public virtual void MarkComplete()
    {
        IsCompleted = true;
    }

    public abstract void DisplayGoalProgress();
    public abstract int GetPoints();
    public virtual void SetCompletedStatus(bool isCompleted)
    {
        IsCompleted = isCompleted;
    }
    public virtual void SetPoints(int points)
    {
        // To be implemented in child classes
    }
}
