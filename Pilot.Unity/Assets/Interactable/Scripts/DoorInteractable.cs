using UnityEngine;

public class DoorInteractable : BaseInteractable
{
    [SerializeField]
    private Scenes scene;

    public override void Interact()
    {
        SceneUtils.Load(scene);
    }
}
