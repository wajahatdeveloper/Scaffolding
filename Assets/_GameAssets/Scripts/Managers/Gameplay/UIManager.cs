using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI MANAGER
/// Handles all UI Interactions for In Game Scene (Gameplay)
/// </summary>
public class UIManager : SingletonBehaviour<UIManager>
{
    [Header("References")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    #region PanelAccessors

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

    public void ShowLosePanel()
    {
        losePanel.SetActive(true);
    }
    
    public void HideWinPanel()
    {
        winPanel.SetActive(false);
    }

    public void HideLosePanel()
    {
        losePanel.SetActive(false);
    }

    #endregion
}