using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractableProvider
{
    public readonly string INTERACTABLE_TAG = "Interactable";

    private float interactionDistance;

    public InteractableProvider(float interactionDistance)
    {
        this.interactionDistance = interactionDistance;
    }

    public IInteractable GetInteractable(Transform player)
    {
        var interactables = FindInteractables();
        return ClosestInteractableNotTooFar(interactables, player);
    }

    private List<Transform> FindInteractables()
    {
        return GameObject.FindGameObjectsWithTag(INTERACTABLE_TAG).Select(g => g.transform).ToList();
    }

    private IInteractable ClosestInteractableNotTooFar(List<Transform> transforms, Transform target)
    {
        if (transforms.Count < 1)
        {
            return null;
        }
        var closest = transforms[0];
        foreach (var i in transforms)
        {
            if (IsACloserThanB(aPos: i.position, bPos: closest.position, target: target.position))
            {
                closest = i;
            }
        }
        //if the interactable is too far from the player
        if (IsInteractableTooFar(closest: closest, player: target))
        {
            return null;
        }

        return closest.GetComponentInChildren<IInteractable>();
    }

    private bool IsACloserThanB(Vector3 aPos, Vector3 bPos, Vector3 target)
    {
        float aDist = (target - aPos).magnitude;
        float bDist = (target - bPos).magnitude;
        return aDist < bDist;
    }

    private bool IsInteractableTooFar(Transform closest, Transform player)
    {
        float distanceToPlayer = (closest.position - player.position).magnitude;
        //if the interactable is too far from the player
        return distanceToPlayer > interactionDistance;
    }

}
