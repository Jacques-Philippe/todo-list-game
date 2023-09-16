using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Action OnPlayerInteracted;
    public Action OnInteractableLost;
    public Action OnInteractableFound;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float interactionDistance;

    private InteractableProvider interactableProvider;

    private IInteractable activeInteractable = null;
    /// <summary>
    /// The player's currently active interactable element
    /// </summary>
    public IInteractable ActiveInteractable
    {
        private set
        {
            if (value == null)
            {
                //reset active interactable, if any
                if (this.activeInteractable != null)
                {
                    this.activeInteractable = value;
                    this.OnInteractableLost?.Invoke();
                }
                return;
            }
            //else if interactable is detected

            //if the same interactable is detected, continue
            if (this.activeInteractable == value)
            {
                return;
            }

            //if a new interactable is detected, update
            this.activeInteractable = value;
            this.OnInteractableFound?.Invoke();

        }
        get => activeInteractable;
    }

    private void Awake()
    {
        this.interactableProvider = new InteractableProvider(interactionDistance: this.interactionDistance);
    }

    void Update()
    {
        var i = interactableProvider.GetInteractable(player);
        this.ActiveInteractable = i;

        if (Input.GetKeyDown(KeyCode.E))
        {
            i.Interact();
        }
    }

}
