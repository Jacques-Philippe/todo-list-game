using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour, IInteractable
{
    public abstract void Interact();
}
