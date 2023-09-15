using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SfxButtonClick : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlaySfx);
    }

    private void PlaySfx()
    {
        AudioManager.PlayUISound(AudioManager.GetAudioData().buttonClick);
    }
}