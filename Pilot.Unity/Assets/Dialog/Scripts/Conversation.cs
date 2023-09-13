using System;

public class Conversation
{
    private PhraseNode current;
    public PhraseNode Current {
        private set {
            this.current = value;
            this.CurrentChanged?.Invoke();

            if (this.Current == null)
            {
                this.ConversationEnded?.Invoke();
            }
        }
        get => this.current;
    }
    /// <summary>
    /// Event fired for the currently active conversation node changed
    /// </summary>
    public Action CurrentChanged;

    public Action ConversationEnded;

    public Conversation(PhraseNode start)
    {
        this.Current = start;
    }

    /// <summary>
    /// Move to the next phrase node given the current phrase node is a default phase node
    /// </summary>
    /// <returns></returns>
    public void Next()
    {
        if (this.Current is not DefaultPhraseNode defaultPhraseNode)
        {
            return;
        }
        this.Current = defaultPhraseNode.Next;
    }

    /// <summary>
    /// Move to the next phrase node given the incoming choice given the current phrase node is a prompt phrase node
    /// </summary>
    /// <param name="option"></param>
    /// <returns></returns>
    public void Next(DefaultPhraseNode option)
    {
        if (this.Current is not PromptPhraseNode promptPhraseNode)
        {
            return;
        }

        this.Current = promptPhraseNode.NextPhraseNodeGivenInput(option);
    }
}
