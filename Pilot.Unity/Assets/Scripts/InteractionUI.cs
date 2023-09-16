using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    [SerializeField]
    private PlayerInteraction playerInteraction;

    [SerializeField]
    private GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        playerInteraction.OnInteractableFound += HandleInteractableFound;
        playerInteraction.OnInteractableLost += HandleInteractableLost;

        this.HideUI();
    }

    private void HandleInteractableFound()
    {
        this.ShowUI();
    }

    private void HandleInteractableLost()
    {
        this.HideUI();
    }

    private void ShowUI()
    {
        this.ui.SetActive(true);
    }

    private void HideUI()
    {
        this.ui.SetActive(false);
    }
}
