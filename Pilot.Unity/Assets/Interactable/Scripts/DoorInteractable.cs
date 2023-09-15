using UnityEngine;

public class DoorInteractable : BaseInteractable
{
    [SerializeField]
    private Scenes leadsToScene;

    public override void Interact()
    {
        SceneUtils.Load(leadsToScene);
    }
}
