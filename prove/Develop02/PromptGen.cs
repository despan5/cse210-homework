namespace Develope02;

    public class PromptGen
    {
        private List<string> prompts = new List<string> {
            "Who do you trust most? Why?",
            "What are your strengths in relationships (kindness, empathy, etc.)?",
            "How do you draw strength from loved ones?",
            "What do you value most in relationships (trust, respect, sense of humor, etc.)?",
            "How does work fulfill you? Does it leave you wanting more?",
            "What are your career ambitions?",
            "Finish this sentence: “My life would be incomplete without …”"
            };

    private Random random = new Random();

    public string getPrompt()
    {
        return prompts[random.Next(1, prompts.Count)];
    }
}