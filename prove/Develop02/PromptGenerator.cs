using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts;

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }
}
