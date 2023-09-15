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
    public PanelBase modeSelectionPanel;
    public PanelBase settingsPanel;

    private void Start()
    {
        DebugX.Log($"{LogClassName} : Initializing Main Menu..",LogFilters.None, gameObject);

        GraphicsManager.Instance.Init();

        settingsPanel.Init();
        modeSelectionPanel.Init();

        LoadingPanel.Instance.HideIfShown();   // For Loading persisted from Gameplay Scene

        //* For Testing
        AudioManager.PlayMusic(AudioData.Instance.backgroundMusic);
        AudioManager.PlaySound(AudioData.Instance.playerWin, true);
    }

    public void OnClick_Play()
    {
        PlayButtonClickSound();
        DebugX.Log($"{LogClassName} : Play Button Clicked.", LogFilters.None, gameObject);
        modeSelectionPanel.Show();
    }

    public void OnClick_Settings()
    {
        PlayButtonClickSound();
        DebugX.Log($"{LogClassName} : Settings Button Clicked.", LogFilters.None, gameObject);
        settingsPanel.Show();
    }

    private void PlayButtonClickSound()
    {
        AudioManager.PlayUISound(AudioData.Instance.buttonClick);
    }
}