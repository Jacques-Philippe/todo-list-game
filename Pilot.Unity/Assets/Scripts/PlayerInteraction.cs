using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private ConversationManager conversationManager;

    //TODO Sep 13 2023 replace with an interaction flow that finds the nearest conversation provider
    [SerializeField]
    private ConversationProvider conversationProvider;

    public Action OnPlayerInteracted;
 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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

            //Assume no conversation is open
            //Get the conversation from the provider
            //Set it as current conversation
            //Start the conversation
            //if the conversation is started and the node is a default node, keep going through the nodes
            //else wait for input from elsewhere
            Debug.Log("Player interacted");

            //conversationManager.Next();
            
            //OnPlayerInteracted?.Invoke();
        }   
    }
}
