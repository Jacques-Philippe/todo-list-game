using TMPro;
using UnityEngine;

public class ConversationUI : MonoBehaviour
{
    [SerializeField]
    private GameObject window;

    [SerializeField]
    private TextMeshProUGUI speakerText;

    [SerializeField]
    private TextMeshProUGUI contentText;

    public string Speaker {
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
        this.window.SetActive(true);
    }

    public void Close()
    {
        this.window.SetActive(false);
    }

}
