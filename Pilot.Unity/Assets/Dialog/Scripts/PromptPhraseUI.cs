using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PromptPhraseUI : DefaultPhraseUI
{
    [SerializeField]
    private PromptPhraseOptionUI promptOptionPrefab;

    [SerializeField]
    private Transform optionContainer;

    private List<PromptPhraseOptionUI> options = new List<PromptPhraseOptionUI>();

    public List<string> Options {
        set {
            ClearOptions();
            PopulateOptions(value);
        }
        get => options.Select(o => o.Content).ToList();
    }

    /// <summary>
    /// Event fired for a given prompt selected
    /// </summary>
    public Action<string> OnPromptSelected;

    private void ClearOptions()
    {
        foreach(var o in options)
        {
            GameObject.Destroy(o);
        }
        this.options.Clear();
    }

    private void PopulateOptions(List<string> incoming)
    {
        foreach(var content in incoming)
        {
            PromptPhraseOptionUI ui = Instantiate(promptOptionPrefab);
            //Set in scene
            ui.gameObject.SetActive(true);
            ui.transform.SetParent(optionContainer, false);

            //Populate element state
            ui.Content = content;
            ui.OnButtonClicked += () => OnPromptSelected?.Invoke(content);

            //Add to prompt state
            this.options.Add(ui);
        }
    }
}
