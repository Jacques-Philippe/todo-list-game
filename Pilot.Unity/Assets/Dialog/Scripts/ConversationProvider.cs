using System.Collections.Generic;
using UnityEngine;

public class ConversationProvider : MonoBehaviour
{
    public Conversation Conversation { private set; get; }

    private void Awake()
    {
        ConversationMember jerry = new ConversationMember("Jerry");
        ConversationMember player = new ConversationMember("Player");

        DefaultPhraseNode end_good = new DefaultPhraseNode("I'm glad!", jerry);
        DefaultPhraseNode end_bad = new DefaultPhraseNode("That's too bad!", jerry);

        DefaultPhraseNode good = new DefaultPhraseNode("Good.", player, end_good);
        DefaultPhraseNode bad = new DefaultPhraseNode("Bad.", player, end_bad);
        List<DefaultPhraseNode> options = new List<DefaultPhraseNode>()
        {
            good, bad
        };

        PromptPhraseNode phrase2 = new PromptPhraseNode("How are you?", jerry, options);
        DefaultPhraseNode phrase1 = new DefaultPhraseNode("Hi.", jerry, phrase2);

        this.Conversation = new Conversation(phrase1);
    }
}
