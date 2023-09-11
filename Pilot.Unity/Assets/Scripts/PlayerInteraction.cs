using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private ConversationManager conversationManager;

    public Action OnPlayerInteracted;
    private void Start()
    {
        conversationManager.StartConversation();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player interacted");

            conversationManager.Next();
            
            OnPlayerInteracted?.Invoke();
        }   
    }
}
