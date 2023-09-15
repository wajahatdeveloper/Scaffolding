using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelectionPanel : PanelBase
{
    private const string LogClassName = "ModeSelectionPanel";

    [TitleGroup("Buttons")]
    public Button backButton;
    
    [TitleGroup("Mode Buttons")]
    public Button storyMode;
    public Button freeRoamMode;

    public int SelectedModeNumber
    {
        get => PlayerPrefsX.GetInt("SelectedModeNumber", 1);
        set => PlayerPrefsX.SetInt("SelectedModeNumber", value);
    }
    
    public void OnClick_StoryMode()
    {
        DebugX.Log($"{LogClassName} : Story Mode Button Clicked.", LogFilters.None, gameObject);
        SelectedModeNumber = 1;
        
        MainMenu.Instance.levelSelectionPanel.Show();
        Hide();
    }

    public void OnClick_FreeRoamMode()
    {
        DebugX.Log($"{LogClassName} : FreeRoam Mode Button Clicked.", LogFilters.None, gameObject);
        SelectedModeNumber = 2;

        MainMenu.Instance.levelSelectionPanel.Show();
        Hide();
    }

    public void OnClick_Back()
    {
        DebugX.Log($"{LogClassName} : Back Button Clicked.", LogFilters.None, gameObject);
        MainMenu.Instance.startScreenPanel.Show();
        Hide();
    }
}