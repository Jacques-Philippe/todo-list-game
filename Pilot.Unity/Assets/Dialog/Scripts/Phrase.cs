

using System.Collections.Generic;

public class PhraseNode
{
    public string Content { private set; get; }
    public ConversationMember Speaker { private set; get; }

    public PhraseNode(string content, ConversationMember from)
    {
        this.Content = content;
        this.Speaker = from;
    }

    public new string ToString()
    {
        return $"{Speaker.Name}: {Content}";
    }
}

/// <summary>
/// A phrase which only requires for input to continue
/// </summary>
public class DefaultPhraseNode : PhraseNode
{
    public PhraseNode Next { private set; get; }

    public DefaultPhraseNode(string content, ConversationMember from, PhraseNode next = null) : base(content, from)
    {
        this.Next = next;
    }

    public new string ToString()
    {
        return $"{nameof(DefaultPhraseNode)} {Speaker.Name}: {Content}";
    }
}

/// <summary>
/// A phrase which requires a phrase choice from the player before the conversation can continue
/// </summary>
public class PromptPhraseNode : PhraseNode
{
    public List<DefaultPhraseNode> Options { private set; get; }

    public PromptPhraseNode(string content, ConversationMember from, List<DefaultPhraseNode> options) : base(content, from)
    {
        this.Options = options;
    }

    public new string ToString()
    {
        string message = $"{nameof(PromptPhraseNode)} {Speaker.Name}: {Content}\nOptions:\n";
        foreach(var o in this.Options)
        {
            message += $"\t{o.Content}\n";
        }
        return message;
    }

    /// <summary>
    /// Return the next phrase node 
    /// </summary>
    /// <param name="chosen">a Phrase from <see cref="Options"/></param>
    /// <returns></returns>
    public PhraseNode NextPhraseNodeGivenInput(DefaultPhraseNode chosen)
    {
        //given the chosen option
        if (!this.Options.Contains(chosen))
        {
            throw new System.Exception("The chosen input phrase must belong in the options list");
        }
        //else the option is valid
        return chosen.Next;
    }
}
