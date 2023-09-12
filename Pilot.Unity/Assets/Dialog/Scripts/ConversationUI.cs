using System;
using System.Linq;
using UnityEngine;

public class ConversationUI : MonoBehaviour
{
    [SerializeField]
    private GameObject window;

    [SerializeField]
    private DefaultPhraseUI defaultPhraseUI;

    [SerializeField]
    private PromptPhraseUI promptPhraseUI;

    /// <summary>
    /// Event fired for the player makes a selection on a prompt
    /// </summary>
    public Action<PhraseNode> OnPromptOptionSelected;

    private PhraseNode currentNode;

    private void Start()
    {
        this.promptPhraseUI.OnPromptSelected += (selectedPromptContent) =>
        {
            if (currentNode is PromptPhraseNode promptPhraseNode)
            {
                PhraseNode selectedOption = promptPhraseNode.Options.Where(o => o.Content == selectedPromptContent).FirstOrDefault();
                if (selectedOption == null)
                {
                    throw new Exception($"No match was found from prompt options for content {selectedPromptContent}");
                }
                this.OnPromptOptionSelected?.Invoke(selectedOption);
            }
        };
    }

    public void Display(PhraseNode node)
    {
        this.CloseAll();
        this.currentNode = node;

        if (node is DefaultPhraseNode)
        {
            defaultPhraseUI.Open();
            this.SetSpeakerAndContent(node, defaultPhraseUI);
        }
        else if (node is PromptPhraseNode promptPhraseNode)
        {
            promptPhraseUI.Open();
            this.SetSpeakerAndContent(node, promptPhraseUI);
            promptPhraseUI.Options = promptPhraseNode.Options.Select(o => o.Content).ToList();
        }
    }

    public void Close()
    {
        this.CloseAll();
    }

    private void SetSpeakerAndContent(PhraseNode node, DefaultPhraseUI phraseUI)
    {
        phraseUI.Speaker = node.Speaker.Name;
        phraseUI.Content = node.Content;
    }

    private void CloseAll()
    {
        defaultPhraseUI.Close();
        promptPhraseUI.Close();
    }

}
