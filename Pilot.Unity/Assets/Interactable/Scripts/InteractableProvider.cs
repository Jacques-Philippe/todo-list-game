using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractableProvider
{
    public readonly string INTERACTABLE_TAG = "Interactable";

    public IInteractable GetInteractable(Transform player)
    {
        var interactables = FindInteractables();
        return Closest(interactables, player);
    }

    private List<Transform> FindInteractables()
    {
        return GameObject.FindGameObjectsWithTag(INTERACTABLE_TAG).Select(g => g.transform).ToList();
    }

    private IInteractable Closest(List<Transform> transforms, Transform target)
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

        return closest.GetComponentInChildren<IInteractable>();
    }

    private bool IsACloserThanB(Vector3 aPos, Vector3 bPos, Vector3 target)
    {
        float aDist = (target - aPos).magnitude;
        float bDist = (target - bPos).magnitude;
        return aDist < bDist;
    }
}
