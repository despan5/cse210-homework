using System;

internal class PromptGen
{
    private List<string> prompts = new List<string> {





    }

    private Random random = new Random();

    public string getPrompt()
    {
        return prompts[random.Next(1, prompts.Count)];
    }
}