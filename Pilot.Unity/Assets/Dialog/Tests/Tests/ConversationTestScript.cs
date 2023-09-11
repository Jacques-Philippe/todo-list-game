using NUnit.Framework;

public class ConversationTestScript
{
    ConversationMember john = new ConversationMember("John");
    ConversationMember player = new ConversationMember("Player");

    private PhraseNode leaf = null;
    private PhraseNode root = null;


    private PhraseNode GetLeaf()
    {
        if (this.leaf == null)
        {
            this.leaf = new PhraseNode(content: "Good", from: player);
        }
        return this.leaf;
    }

    private PhraseNode GetRoot()
    {
        if (this.root == null)
        {
            this.root = new DefaultPhraseNode(content: "How are you today?", from: john, next: GetLeaf());
        }
        return this.root;
    }

    private Conversation CreateConversation()
    {
        return new Conversation(GetRoot());
    }

    [Test]
    public void DefaultPhraseNodeIsProperlyInitialized()
    {
        var defaultPhraseNode = new DefaultPhraseNode("Hello world", john);
        Assert.That(defaultPhraseNode.Speaker != null);
        Assert.That(defaultPhraseNode.Content != null);
    }


    /// <summary>
    /// Conversation constructor initializes the current phrase for that conversation
    /// </summary>
    [Test]
    public void ConversationConstructorShouldInitializeCurrentPhrase()
    {
        Conversation conversation = CreateConversation();
        var currentPhrase = conversation.Current;

        Assert.That(currentPhrase != null);
        Assert.That(!string.IsNullOrEmpty(currentPhrase.Content));
        Assert.That(currentPhrase.Speaker != null);
    }


    /// <summary>
    /// A -> B
    /// </summary>
    [Test]
    public void SimplePhraseChainWorksAsExpected()
    {
        Conversation conversation = this.CreateConversation();

        Assert.That(conversation.Current == GetRoot());

        conversation.Next();
        
        Assert.That(conversation.Current == GetLeaf());
    }
}
