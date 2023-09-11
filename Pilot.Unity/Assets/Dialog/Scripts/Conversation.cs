using System;

public class Conversation
{
    private Phrase current;
    public Phrase Current {
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

    public Conversation(Phrase start)
    {
        this.Current = start;
    }

    public Phrase Next()
    {
        this.Current = this.Current.Next;
        if (this.Current == null)
        {
            this.ConversationEnded?.Invoke();
        }
        return this.Current;
    }
}
