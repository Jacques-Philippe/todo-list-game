

public class Phrase
{
    public string Content { private set; get; }
    public ConversationMember Member { private set; get; }
    public Phrase Next { private set; get; }

    public Phrase(string content, ConversationMember from, Phrase next = null)
    {
        this.Content = content;
        this.Member = from;
        this.Next = next;
    }

    public new string ToString()
    {
        return $"{Member.Name}: {Content}";
    }

}
