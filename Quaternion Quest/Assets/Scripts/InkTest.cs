using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkTest : MonoBehaviour 
{

    public TextAsset inkAsset;
    public Text text;
    public Button[] button;
    private Story ink_story;
    bool storyNeeded;

	// Use this for initialization
	void Awake () 
    {
        ink_story = new Story(inkAsset.text);
        storyNeeded = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!ink_story.canContinue && ink_story.currentChoices.Count == 0) 
        {
            gameObject.SetActive(false);
            // consider having a button to manually turn the canvas off
        }

        while(ink_story.canContinue) {
            text.text = ink_story.ContinueMaximally();

            if (ink_story.currentChoices.Count > 0)
            {
                for (int i = 0; i < button.Length; i++) 
                {
                    button[i].gameObject.SetActive(false);
                }

                for (int i = 0; i < ink_story.currentChoices.Count; ++i)
                {
                    button[i].gameObject.SetActive(true);
                    Choice choice = ink_story.currentChoices[i];
                    Text choiceText = button[i].GetComponentInChildren<UnityEngine.UI.Text>();
                    text.text = "Choice " + (i + 1) + ". " + choice.text;
                    choiceText.text = ink_story.currentChoices[i].text;

                    int index = i;

                    button[i].onClick.AddListener(()=>ChoiceSelected(index));
                }
            }
        }

        string savedJson = ink_story.state.ToJson();
        ink_story.state.LoadJson(savedJson);
	}

    public void ChoiceSelected(int id)
    {
        ink_story.ChooseChoiceIndex(id);
        storyNeeded = true;
    }
}
