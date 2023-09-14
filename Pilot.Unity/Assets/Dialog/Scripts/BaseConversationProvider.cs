using UnityEngine;

public abstract class BaseConversationProvider : MonoBehaviour, IConversationProvider
{
    public Conversation Conversation { protected set; get; }

    public abstract void InitializeConversation();

    protected void Awake()
    {
        this.InitializeConversation();
    }

}
