using System;

public class Conversation
{
    public Phrase Current { private set; get; } = null;
    public Action CurrentChanged;

    public Conversation(Phrase start)
    {
        this.Current = start;
    }

    public void Next()
    {
        this.Current = this.Current.Next;
    }
}
