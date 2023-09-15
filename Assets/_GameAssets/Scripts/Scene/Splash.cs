using UnityEngine;

public class Splash : MonoBehaviour
{
    private const string LogClassName = "Splash";

    [Header("Attributes")]
    public float nextSceneDelay = 2.0f;

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    private void Start()
    {
        this.Invoke(() =>
        {
            DebugX.Log($"{LogClassName} : Initializations Complete Loading Next Scene..", LogFilters.None, gameObject);

            SceneManagerX.LoadNextScene();

        } , nextSceneDelay);
    }
}