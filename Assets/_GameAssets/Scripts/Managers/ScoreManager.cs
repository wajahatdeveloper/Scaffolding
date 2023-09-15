using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// SCORE MANAGER
/// Handles all Score Interactions for In Game Scene (Gameplay)
/// </summary>
public class ScoreManager : SingletonBehaviour<ScoreManager>
{
    private const string LogClassName = "ScoreManager";

    [InfoBox("This Script Exposes the Following Events\n" +
             "OnScoreUpdated<int>\n" +
             "OnScoreUpdatedDelta<int>")]
    public Action<int> OnScoreUpdated = null;
    public Action<int> OnScoreUpdatedDelta = null;

    [ShowInInspector, ReadOnly]
    private int scoreValue = 0;

    private int Score
    {
        get => scoreValue;
        set
        {
            //* DebugX.Log($"{LogClassName} : Score Set to " + value, LogFilters.Economy,null);
            scoreValue = value;
        }
    }

    private void OnEnable()
    {
        GameplayManager.Instance.OnGameplayStart += Handle_OnGameplayStart;
    }
    
    private void OnDisable()
    {
        if (GameplayManager.Instance == null) { return; }
        GameplayManager.Instance.OnGameplayStart -= Handle_OnGameplayStart;
    }

    private void Handle_OnGameplayStart()
    {
        StartCoroutine(Routine_FirstScoreUpdate());
    }

    private IEnumerator Routine_FirstScoreUpdate()
    {
        yield return new WaitForSeconds(0.1f);
        
        DebugX.Log($"{LogClassName} : First Score Updated.", LogFilters.Events, gameObject);
        OnScoreUpdated?.Invoke(Score);
    }

    [Button]
    public void SetScore(int newScore, bool directSetWithoutEvent = false)
    {
        Score = newScore;

        if (directSetWithoutEvent)
        {
            return;
        }
        
        //* DebugX.Log($"{LogClassName} : Score Updated.", LogFilters.Events, gameObject);
        OnScoreUpdated?.Invoke(Score);
    }
    
    public int GetScore()
    {
        return Score;
    }
    
    [Button]
    public void AddScore(int scoreDelta)
    {
        DebugX.Log($"{LogClassName} : Adding Score [delta = {scoreDelta}]", LogFilters.Economy,null);

        Score += scoreDelta;
        //* DebugX.Log($"{LogClassName} : Score Updated.", LogFilters.Events, gameObject);
        OnScoreUpdated?.Invoke(Score);
        OnScoreUpdatedDelta?.Invoke(scoreDelta);
    }
    
    [Button]
    public void SubtractScore(int scoreDelta)
    {
        DebugX.Log($"{LogClassName} : Subtracting Score [delta = {scoreDelta}]", LogFilters.Economy,null);

        Score -= scoreDelta;
        //* DebugX.Log($"{LogClassName} : Score Updated.", LogFilters.Events, gameObject);
        OnScoreUpdated?.Invoke(Score);
        OnScoreUpdatedDelta?.Invoke(-scoreDelta);
    }
    
    [Button]
    public void ClearScore()
    {
        Score = 0;

        //* DebugX.Log($"{LogClassName} : Score Updated.", LogFilters.Events, gameObject);
        OnScoreUpdated?.Invoke(Score);
    }
}