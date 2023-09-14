using UnityEngine;

public class ConversationInteractable : BaseInteractable
{
    [SerializeField]
    private ConversationManager conversationManager;

    //TODO Sep 13 2023 replace with an interaction flow that finds the nearest conversation provider
    [SerializeField]
    private BaseConversationProvider conversationProvider;

    public override void Interact()
    {
        switch (conversationManager.State)
        {
            case ConversationManager.ConversationState.CLOSED:
                {
                    var conversation = conversationProvider.Conversation;
                    this.conversationManager.StartConversation(conversation);
                    break;
                }
            case ConversationManager.ConversationState.OPEN:
                {
                    conversationManager.Next();
                    break;
                }
        }
    }
}
