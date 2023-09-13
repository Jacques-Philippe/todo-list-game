using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    [SerializeField]
    private ConversationUI conversationUI;

    public Conversation Conversation { private set; get; }

    public enum ConversationState { CLOSED, OPEN };
    public ConversationState State { private set; get; } = ConversationState.CLOSED;

    private void Start()
    {
        this.conversationUI.OnPromptOptionSelected += (phraseNode) => {
            this.Conversation.Next(phraseNode as DefaultPhraseNode);
        };
    }

    public void StartConversation(Conversation c)
    {
        InitializeConversation(c);
        this.conversationUI.Display(this.Conversation.Current);
        this.State = ConversationState.OPEN;
    }

    /// <summary>
    /// Move onto next default node, if any, otherwise if the current node is a prompt input will do nothing, and instead waits for input
    /// </summary>
    public void Next()
    {
        if (this.Conversation.Current is not DefaultPhraseNode)
        {
            return;
        }
        this.Conversation.Next();
    }

    private void InitializeConversation(Conversation conversation)
    {
        conversation.CurrentChanged += () => this.conversationUI.Display(this.Conversation.Current);

        conversation.ConversationEnded += () => FinishConversation();

        this.Conversation = conversation;
    }

    private void FinishConversation()
    {
        this.conversationUI.Close();
        this.Conversation = null;
        this.State = ConversationState.CLOSED;
    }

}
