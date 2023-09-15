using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionPanel : PanelBase
{
    private const string LogClassName = "LevelSelectionPanel";

    [TitleGroup("Level Buttons")]
    public List<Button> levelButtons = new();

    public void OnClick_Level(int index)
    {
        DebugX.Log($"{LogClassName} : Level {index} Button Clicked.", LogFilters.None, gameObject);
    }

    public void OnClick_Back()
    {
        DebugX.Log($"{LogClassName} : Back Button Clicked.", LogFilters.None, gameObject);
        Hide();
    }
}