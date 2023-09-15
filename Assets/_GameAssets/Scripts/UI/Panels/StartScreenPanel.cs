using Sirenix.OdinInspector;
using UnityEngine.UI;

public class StartScreenPanel : PanelBase
{
    private const string LogClassName = "StartScreenPanel";
    
    [TitleGroup("Buttons")]
    public Button playButton;
    public Button settingsButton;
    public Button shopButton;

    public override void Init()
    {
    }
    
    public void OnClick_Play()
    {
        DebugX.Log($"{LogClassName} : Play Button Clicked.", LogFilters.None, gameObject);
        MainMenu.Instance.modeSelectionPanel.Show();
        Hide();
    }

    public void OnClick_Settings()
    {
        DebugX.Log($"{LogClassName} : Settings Button Clicked.", LogFilters.None, gameObject);
        MainMenu.Instance.settingsPanel.Show();
        Hide();
    }
    
    public void OnClick_Shop()
    {
        DebugX.Log($"{LogClassName} : Shop Button Clicked.", LogFilters.None, gameObject);
        MainMenu.Instance.shopPanel.Show();
        Hide();
    }
}