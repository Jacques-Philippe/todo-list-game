using TMPro;
using UnityEngine;

public class PromptPhraseOptionUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textElement;

    public string Content { set => textElement.text = value; get => textElement.text; }
}
