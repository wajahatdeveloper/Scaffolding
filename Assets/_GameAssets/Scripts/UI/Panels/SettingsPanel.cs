using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    private const string LogClassName = "MainMenu";

    [TitleGroup("Audio")] public Slider soundVolumeSlider;
    public Slider musicVolumeSlider;

    [TitleGroup("Graphics")] public Button graphicsLowButton;
    public Button graphicsMediumButton;
    public Button graphicsHighButton;

    public void OnClick_GraphicsLow()
    {
        DebugX.Log($"{LogClassName} : Graphics Low Button Clicked.", LogFilters.None, gameObject);
    }

    public void OnClick_GraphicsMedium()
    {
        DebugX.Log($"{LogClassName} : Graphics Medium Button Clicked.", LogFilters.None, gameObject);
    }

    public void OnClick_GraphicsHigh()
    {
        DebugX.Log($"{LogClassName} : Graphics High Button Clicked.", LogFilters.None, gameObject);
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