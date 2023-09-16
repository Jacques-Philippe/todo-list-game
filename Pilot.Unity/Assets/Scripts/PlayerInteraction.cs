using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Action OnPlayerInteracted;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float interactionDistance;

    private InteractableProvider interactableProvider;

    private void Awake()
    {
        this.interactableProvider = new InteractableProvider(interactionDistance: this.interactionDistance);
    }

    void Update()
    {
        var i = interactableProvider.GetInteractable(player);
        Debug.Log($"Interactable {i}");

        if (Input.GetKeyDown(KeyCode.E))
        {
            i.Interact();
        }
    }

}
