using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PromptPhraseOptionUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textElement;

    [SerializeField]
    private Button button;

    public string Content { set => textElement.text = value; get => textElement.text; }

    public Action OnButtonClicked;

    private void Awake()
    {
        button.onClick.AddListener(() => OnButtonClicked?.Invoke());
    }
}
