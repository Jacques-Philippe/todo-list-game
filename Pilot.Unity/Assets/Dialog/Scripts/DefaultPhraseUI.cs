using TMPro;
using UnityEngine;

public class DefaultPhraseUI : MonoBehaviour
{
    [SerializeField]
    protected TextMeshProUGUI speakerText;

    [SerializeField]
    protected TextMeshProUGUI contentText;

    public string Speaker
    {
        set
        {
            speakerText.text = value;
        }
        get
        {
            return this.speakerText.text;
        }
    }
    public string Content
    {
        set
        {
            contentText.text = value;
        }
        get
        {
            return this.contentText.text;
        }
    }

    public void Open()
    {
        this.gameObject.SetActive(true);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
