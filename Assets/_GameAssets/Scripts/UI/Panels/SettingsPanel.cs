using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    private const string LogClassName = "MainMenu";

    [TitleGroup("Audio")]
    public Slider soundVolumeSlider;
    public Slider musicVolumeSlider;

    [TitleGroup("Graphics")]
    public Toggle graphicsLowToggle;
    public Toggle graphicsMediumToggle;
    public Toggle graphicsHighToggle;

    public void OnClick_GraphicsLow()
    {
        DebugX.Log($"{LogClassName} : Graphics Low Button Clicked.", LogFilters.None, gameObject);
        GraphicsManager.Instance.SetGraphicsLow();
    }

    public void OnClick_GraphicsMedium()
    {
        DebugX.Log($"{LogClassName} : Graphics Medium Button Clicked.", LogFilters.None, gameObject);
        GraphicsManager.Instance.SetGraphicsMedium();
    }

    public void OnClick_GraphicsHigh()
    {
        DebugX.Log($"{LogClassName} : Graphics High Button Clicked.", LogFilters.None, gameObject);
        GraphicsManager.Instance.SetGraphicsHigh();
    }

    public void OnValueChanged_SoundVolume(float value)
    {
        DebugX.Log($"{LogClassName} : Sound Volume => {value}", LogFilters.None, gameObject);
    }

    public void OnValueChanged_MusicVolume(float value)
    {
        DebugX.Log($"{LogClassName} : Music Volume => {value}", LogFilters.None, gameObject);
    }

    public void OnClick_Back()
    {
        DebugX.Log($"{LogClassName} : Back Button Clicked.", LogFilters.None, gameObject);
        gameObject.SetActive(false);
    }
}