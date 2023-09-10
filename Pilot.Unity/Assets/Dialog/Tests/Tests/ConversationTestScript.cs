using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ConversationTestScript
{
    ConversationMember john = new ConversationMember("John");
    ConversationMember player = new ConversationMember("Player");

    private Phrase leaf = null;
    private Phrase root = null;


    private Phrase GetLeaf()
    {
        if (this.leaf == null)
        {
            this.leaf = new Phrase(content: "Good", from: player);
        }
        return this.leaf;
    }

    private Phrase GetRoot()
    {
        if (this.root == null)
        {
            this.root = new Phrase(content: "How are you today?", from: john, next: GetLeaf());
        }
        return this.root;
    }

    private Conversation CreateConversation()
    {
        return new Conversation(GetRoot());
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
        Assert.That(currentPhrase.Member != null);
    }


    /// <summary>
    /// A -> B
    /// </summary>
    [Test]
    public void SimplePhraseChainWorksAsExpected()
    {
        Conversation conversation = this.CreateConversation();

        Assert.That(conversation.Current.Equals(GetRoot()));

        conversation.Next();
        
        Assert.That(conversation.Current == GetLeaf());
    }
}
