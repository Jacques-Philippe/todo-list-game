

public class Phrase
{
    private static int id = 1;
    public string Content { private set; get; }
    public ConversationMember Member { private set; get; }
    public Phrase Next { private set; get; }
    private readonly int instanceId;

    public Phrase(string content, ConversationMember from, Phrase next = null)
    {
        this.Content = content;
        this.Member = from;
        this.Next = next;
        instanceId = id++;
    }

    public new string ToString()
    {
        return $"{Member.Name}: {Content}";
    }

    public bool Equals(Phrase other)
    {
        return this.instanceId == other.instanceId;
    }
}
