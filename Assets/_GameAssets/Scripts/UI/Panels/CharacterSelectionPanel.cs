using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionPanel : PanelBase
{
    private const string LogClassName = "CharacterSelectionPanel";

    [TitleGroup("Character Previews")]
    [SceneObjectsOnly] public GameObject characterPreviewHolder;
    [ReadOnly] public List<GameObject> characterPreviews = new();

    [TitleGroup("Buttons")]
    public Button leftButton;
    public Button rightButton;
    public Button selectButton;
    public Button backButton;

    public int SelectedCharacterNumber
    {
        get => PlayerPrefsX.GetInt("SelectedCharacterNumber", 1);
        set => PlayerPrefsX.SetInt("SelectedCharacterNumber", value);
    }

    private int currentNumber = 0;

    public override void Init()
    {
        characterPreviewHolder.SetActive(false);
        var children = characterPreviewHolder.transform.GetChildren();
        characterPreviews.AddRange(children.Select(x=>x.gameObject));
    }

    protected override void OnAfterShow()
    {
        ShowCharacterPreview(SelectedCharacterNumber);
    }

    protected override void OnBeforeHide()
    {
        HideCharacterPreview();
    }

    public void OnClick_Left()
    {
        currentNumber--;
        if (currentNumber < 1) { currentNumber = 1; }
        
        ShowCharacterPreview(currentNumber);
    }
    
    public void OnClick_Right()
    {
        currentNumber++;
        if (currentNumber > characterPreviews.Count) { currentNumber = characterPreviews.Count; }
        
        ShowCharacterPreview(currentNumber);
    }

    public void OnClick_Select()
    {
        DebugX.Log($"{LogClassName} : Character number {currentNumber} Selected.", LogFilters.None, gameObject);
        SelectedCharacterNumber = currentNumber;
        Hide();
    }

    public void OnClick_Back()
    {
        DebugX.Log($"{LogClassName} : Back Button Clicked.", LogFilters.None, gameObject);
        MainMenu.Instance.levelSelectionPanel.Show();
        Hide();
    }
    
    private void ShowCharacterPreview(int number)
    {
        characterPreviews.ForEach(x => x.SetActive(false));
        characterPreviews[number - 1].SetActive(true);
        characterPreviewHolder.SetActive(true);
    }
    
    private void HideCharacterPreview()
    {
        characterPreviewHolder.SetActive(false);
    }
}