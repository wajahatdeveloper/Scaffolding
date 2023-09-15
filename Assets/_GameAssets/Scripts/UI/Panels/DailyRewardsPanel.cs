using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardsPanel : PanelBase
{
    private const string LogClassName = "DailyRewardsPanel";
    
    [TitleGroup("Buttons")]
    public Button backButton;

    public override void Init()
    {
    }

    public void OnClick_Back()
    {
        DebugX.Log($"{LogClassName} : Back Button Clicked.", LogFilters.None, gameObject);
        MainMenu.Instance.startScreenPanel.Show();
        Hide();
    }
}