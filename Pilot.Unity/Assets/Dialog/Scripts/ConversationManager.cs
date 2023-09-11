using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    [SerializeField]
    private ConversationUI conversationUI;

    private ConversationMember jerry = new ConversationMember("Jerry");
    public Conversation Conversation { private set; get; }

    private void Awake()
    {
        InitializeConversations();
    }

    public void StartConversation()
    {
        this.conversationUI.Open();
        this.UpdateConversationUI(this.Conversation);
    }

    public void Next()
    {
        if (this.Conversation.Next() == null)
        {
            this.Conversation = null;
        }
    }

    private void InitializeConversations()
    {
        Phrase phrase3 = new Phrase("I think.", jerry);
        Phrase phrase2 = new Phrase("My name's Jerry.", jerry, phrase3);
        Phrase phrase1 = new Phrase("Hey.", jerry, phrase2);

        Conversation = new Conversation(phrase1);

        Conversation.CurrentChanged += () =>
        {
            if (Conversation.Current == null)
            {
                return;
            }
            
            this.UpdateConversationUI(this.Conversation);
        };

        Conversation.ConversationEnded += () =>
        {
            this.conversationUI.Close();
        };

    }

    private void UpdateConversationUI(Conversation conversation)
    {
        var phrase = conversation.Current;
        var speaker = phrase.Member.Name;
        var content = phrase.Content;

        this.conversationUI.Speaker = speaker;
        this.conversationUI.Content = content;
    }

}
