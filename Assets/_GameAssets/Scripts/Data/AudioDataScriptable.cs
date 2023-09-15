using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Custom/AudioData")]
public class AudioDataScriptable : ScriptableObject
{
    [TitleGroup("UI Sounds")]
    public AudioClip buttonClick;

    [TitleGroup("Game Sounds")]
    public AudioClip playerWin;

    [TitleGroup("Music")]
    public AudioClip backgroundMusic;
}