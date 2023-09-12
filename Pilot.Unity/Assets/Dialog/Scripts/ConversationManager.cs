using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    [SerializeField]
    private ConversationUI conversationUI;

    public Conversation Conversation { private set; get; }

    private void Awake()
    {
        InitializeConversations();
    }

    private void Start()
    {
        this.conversationUI.OnPromptOptionSelected += (phraseNode) => {
            this.Conversation.Next(phraseNode as DefaultPhraseNode);
        };
    }

    public void StartConversation()
    {
        this.conversationUI.Display(this.Conversation.Current);
    }

    public void Next()
    {
        if (this.Conversation.Current is not DefaultPhraseNode)
        {
            return;
        }
        if (this.Conversation.Next() == null)
        {
            this.Conversation = null;
        }
    }

    private void InitializeConversations()
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

        var conversation = new Conversation(phrase1);

        conversation.CurrentChanged += () =>
        {
            this.conversationUI.Display(this.Conversation.Current);
        };

        conversation.ConversationEnded += () =>
        {
            this.conversationUI.Close();
        };

        this.Conversation = conversation;
    }

}
