using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : PanelBase
{
    private const string LogClassName = "SettingsPanel";

    [TitleGroup("Audio")]
    public Slider soundVolumeSlider;
    public Slider musicVolumeSlider;

    [TitleGroup("Graphics")]
    public Toggle graphicsLowToggle;
    public Toggle graphicsMediumToggle;
    public Toggle graphicsHighToggle;

    public override void Init()
    {
        soundVolumeSlider.minValue = 0.0001f;   // important
        soundVolumeSlider.maxValue = 1f;

        musicVolumeSlider.minValue = 0.0001f;   // important
        musicVolumeSlider.maxValue = 1f;

        soundVolumeSlider.value = AudioManager.Instance.GetSoundVolume();
        musicVolumeSlider.value = AudioManager.Instance.GetMusicVolume();

        int graphicsSelection = GraphicsManager.Instance.GetGraphicsSelection();
        switch (graphicsSelection)
        {
            case 1:
                graphicsLowToggle.isOn = true;
                break;

            case 2:
                graphicsMediumToggle.isOn = true;
                break;

            case 3:
                graphicsHighToggle.isOn = true;
                break;
        }
    }

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
        AudioManager.Instance.SetSoundVolume(value);
    }

    public void OnValueChanged_MusicVolume(float value)
    {
        DebugX.Log($"{LogClassName} : Music Volume => {value}", LogFilters.None, gameObject);
        AudioManager.Instance.SetMusicVolume(value);
    }

    public void OnClick_Back()
    {
        DebugX.Log($"{LogClassName} : Back Button Clicked.", LogFilters.None, gameObject);
        Hide();
    }
}