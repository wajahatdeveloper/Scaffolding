using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class SfxToggleClick : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(PlaySfx);
    }

    private void PlaySfx(bool value)
    {
        AudioManager.PlayUISound(AudioManager.GetAudioData().buttonClick);
    }
}