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

    private InteractableProvider interactableProvider = new InteractableProvider();

    [SerializeField]
    private Transform player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var i = interactableProvider.GetInteractable(player);
            i.Interact();
        }
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        switch (conversationManager.State)
    //        {
    //            case ConversationManager.ConversationState.CLOSED:
    //                {
    //                    var conversation = conversationProvider.Conversation;
    //                    this.conversationManager.StartConversation(conversation);
    //                    break;
    //                }
    //            case ConversationManager.ConversationState.OPEN:
    //                {
    //                    conversationManager.Next();
    //                    break;
    //                }
    //        }

    //        Debug.Log("Player interacted");
    //    }   
    //}
}
