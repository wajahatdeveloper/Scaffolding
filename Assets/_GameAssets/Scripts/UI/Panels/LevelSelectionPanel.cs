using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionPanel : PanelBase
{
    private const string LogClassName = "LevelSelectionPanel";

    [TitleGroup("Level Buttons")]
    public int levelButtonCount = 10;

    [SceneObjectsOnly] public Transform content;
    [AssetsOnly] public GameObject levelButtonPrefab;
    [ReadOnly] public List<LevelButton> levelButtons = new();

    public int SelectedLevelNumber
    {
        get => PlayerPrefsX.GetInt("SelectedLevelNumber", 1);
        set => PlayerPrefsX.SetInt("SelectedLevelNumber", value);
    }
    
    public override void Init()
    {
        for (int i = 0; i < levelButtonCount; i++)
        {
            var btn = Instantiate(levelButtonPrefab, content).GetComponent<LevelButton>();
            btn.number = i + 1;
            btn.button.onClick.AddListener(()=>OnClick_Level(btn.number));
            btn.levelText.text = $"Level {btn.number}";
            levelButtons.Add(btn);
        }
    }

    private void OnClick_Level(int number)
    {
        DebugX.Log($"{LogClassName} : Level {number} Button Clicked.", LogFilters.None, gameObject);
        SelectedLevelNumber = number;

        MainMenu.Instance.characterSelectionPanel.Show();
        Hide();
    }

    public void OnClick_Back()
    {
        DebugX.Log($"{LogClassName} : Back Button Clicked.", LogFilters.None, gameObject);
        MainMenu.Instance.modeSelectionPanel.Show();
        Hide();
    }
}