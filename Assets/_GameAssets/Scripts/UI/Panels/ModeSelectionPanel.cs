using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelectionPanel : PanelBase
{
    private const string LogClassName = "ModeSelectionPanel";

    [TitleGroup("Mode Buttons")]
    public Button storyMode;
    public Button freeRoamMode;

    public void OnClick_StoryMode()
    {
        DebugX.Log($"{LogClassName} : Story Mode Button Clicked.", LogFilters.None, gameObject);
        MainMenu.Instance.levelSelectionPanel.Show();
        Hide();
    }

    public void OnClick_FreeRoamMode()
    {
        DebugX.Log($"{LogClassName} : FreeRoam Mode Button Clicked.", LogFilters.None, gameObject);
    }

    public void OnClick_Back()
    {
        DebugX.Log($"{LogClassName} : Back Button Clicked.", LogFilters.None, gameObject);
        Hide();
    }
}