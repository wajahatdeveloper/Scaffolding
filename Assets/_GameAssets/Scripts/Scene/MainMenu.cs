using Sirenix.OdinInspector;

public class MainMenu : SingletonBehaviour<MainMenu>
{
    private const string LogClassName = "MainMenu";

    [TitleGroup("Data")]
    public GameSettings gameSettings;
    
    [TitleGroup("Panels")]
    public PanelBase startScreenPanel;
    public PanelBase modeSelectionPanel;
    public PanelBase levelSelectionPanel;
    public PanelBase characterSelectionPanel;
    public PanelBase shopPanel;
    public PanelBase settingsPanel;
    public PanelBase dailyRewardsPanel;

    private void Start()
    {
        DebugX.Log($"{LogClassName} : Initializing Main Menu..",LogFilters.None, gameObject);

        GraphicsManager.Instance.Init();
        
        startScreenPanel.Init();
        modeSelectionPanel.Init();
        levelSelectionPanel.Init();
        characterSelectionPanel.Init();
        dailyRewardsPanel.Init();
        settingsPanel.Init();
        shopPanel.Init();

        LoadingPanel.Instance.HideIfShown();   // For Loading persisted from Gameplay Scene
    }

   
}