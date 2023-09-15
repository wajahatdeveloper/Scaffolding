using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDUpdate : MonoBehaviour
{
    [Header("Attributes")]
    public HUDType hudType;

    public string prefixText = "";
    public string initialValue = "";

    [Header("References")]
    public TextMeshProUGUI hudValueText;
    
    private void OnEnable()
    {
        GameplayManager.Instance.OnGameplayStart += OnGameplayStart;
    }

    private void OnGameplayStart()
    {
        hudValueText.text = prefixText + initialValue;

        switch (hudType)
        {
            case HUDType.Score:
                //* ScoreManager.Instance.OnScoreUpdated += Handle_IntValue;
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Handle_ObjectValue(object newValue)
    {
        hudValueText.text = prefixText + newValue.ToString();
    }

    private void Handle_IntValue(int newValue)
    {
        hudValueText.text = prefixText + newValue.ToString();
    }
    
    private void OnDisable()
    {
        switch (hudType)
        {
            case HUDType.Score:
                /*if (ScoreManager.Instance == null) { return; }
                ScoreManager.Instance.OnScoreUpdated -= Handle_IntValue;*/
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        if (GameplayManager.Instance == null) { return; }
        GameplayManager.Instance.OnGameplayStart -= OnGameplayStart;
    }
}

public enum HUDType
{
    Score,   // Score Manager
}