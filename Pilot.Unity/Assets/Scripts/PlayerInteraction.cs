using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
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

}
