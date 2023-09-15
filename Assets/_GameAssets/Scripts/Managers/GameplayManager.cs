using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// GAMEPLAY MANAGER
/// Handles all Gameplay Overview for In Game Scene (Gameplay)
/// </summary>
public class GameplayManager : SingletonBehaviour<GameplayManager>
{
    private const string LogClassName = "GameplayManager";

    [InfoBox("This Script Exposes the Following Events\n" +
             "OnGameplayStart")]
    public Action OnGameplayStart;

    [Header("References")]
    public GameSettings gameSettings;
    public GameObject localPlayer;

    private IEnumerator Start()
    {
        yield return null;      // wait one frame to allow grace period for scene load (background work)

        //* TODO: Load Map Prefab

        DebugX.Log($"{LogClassName} : Gameplay Start.", LogFilters.Events, gameObject);

        OnGameplayStart?.Invoke();  // Signal Everyone The Start of Gameplay

        LoadingPanel.Instance.Hide();   // loading persisted from previous scene
    }

    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
        Debug.Log($"Time Scale Set To {timeScale}");
    }
}