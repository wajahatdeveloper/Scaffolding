using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private const string LogClassName = "MainMenu";

    [TitleGroup("Data")]
    public GameSettings gameSettings;

    [TitleGroup("Buttons")]
    public Button playButton;
    public Button settingsButton;

    [TitleGroup("Panels")]
    public GameObject modeSelectionPanel;
    public GameObject settingsPanel;

    private void Start()
    {
        DebugX.Log($"{LogClassName} : Initializing Main Menu..",LogFilters.None, gameObject);
        LoadingPanel.Instance.HideIfShown();   // For Loading persisted from Gameplay Scene
    }

    public void OnClick_Play()
    {
        DebugX.Log($"{LogClassName} : Play Button Clicked.", LogFilters.None, gameObject);
    }

    public void OnClick_Settings()
    {
        DebugX.Log($"{LogClassName} : Settings Button Clicked.", LogFilters.None, gameObject);
    }
}