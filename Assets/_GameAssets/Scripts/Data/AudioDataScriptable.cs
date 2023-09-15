using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Custom/AudioData")]
public class AudioDataScriptable : ScriptableSingleton<AudioDataScriptable>
{
    [TitleGroup("UI Sounds")]
    public AudioClip buttonClick;

    [TitleGroup("Game Sounds")]
    public AudioClip playerWin;

    [TitleGroup("Music")]
    public AudioClip backgroundMusic;
}

public static class AudioData
{
    public static AudioDataScriptable Instance => AudioDataScriptable.instance;
}