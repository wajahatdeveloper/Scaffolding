using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsManager : SingletonBehaviour<GraphicsManager>
{
    private const string LogClassName = "GraphicsManager";
    private const string graphicsKey = "Graphics";

    public int GetGraphicsSelection()
    {
        return PlayerPrefsX.GetInt(graphicsKey, 2);    // medium by default
    }

    public void Init()
    {
        int graphicsSelection = GetGraphicsSelection();
        switch (graphicsSelection)
        {
            case 1:
                SetGraphicsLow();
                break;

            case 2:
                SetGraphicsMedium();
                break;

            case 3:
                SetGraphicsHigh();
                break;
        }
    }

    public void SetGraphicsLow()
    {
        DebugX.Log($"{LogClassName} : Graphics => Low.", LogFilters.Analytics, gameObject);
        PlayerPrefsX.SetInt(graphicsKey, 1);
    }

    public void SetGraphicsMedium()
    {
        DebugX.Log($"{LogClassName} : Graphics => Medium.", LogFilters.Analytics, gameObject);
        PlayerPrefsX.SetInt(graphicsKey, 2);
    }

    public void SetGraphicsHigh()
    {
        DebugX.Log($"{LogClassName} : Graphics => High.", LogFilters.Analytics, gameObject);
        PlayerPrefsX.SetInt(graphicsKey, 3);
    }
}