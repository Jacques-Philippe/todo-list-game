using System;

public class Conversation
{
    private PhraseNode current;
    public PhraseNode Current {
        private set {
            this.current = value;
            this.CurrentChanged?.Invoke();
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

    public PhraseNode Next()
    {
        if (this.Current is not DefaultPhraseNode defaultPhraseNode){
            return null;
        }
        this.Current = defaultPhraseNode.Next;
        if (this.Current == null)
        {
            this.ConversationEnded?.Invoke();
        }
        return this.Current;
    }
}
