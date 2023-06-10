namespace Develope04;

class BreathingActivity : Activity
{
    private const int breathDuration = 6;

    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void RunActivity(int duration)
    {
        int breathDuration = 6;

        for (int i = 0; i < duration; i += breathDuration * 2)
        {
            Console.WriteLine("Breathe in...");
            DisplayAnimation(breathDuration * 1000);

            Console.WriteLine("Breathe out...");
            DisplayAnimation(breathDuration * 1000);
        }
    }
}
