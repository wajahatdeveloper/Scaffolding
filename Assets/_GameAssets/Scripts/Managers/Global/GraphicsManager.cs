using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsManager : SingletonBehaviour<GraphicsManager>
{
    private const string LogClassName = "GraphicsManager";

    public int SelectedGraphicsLevel
    {
        get => PlayerPrefsX.GetInt("Graphics", 2);    // medium by default
        set => PlayerPrefsX.SetInt("Graphics", value);
    }
    
    public void Init()
    {
        switch (SelectedGraphicsLevel)
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
        SelectedGraphicsLevel = 1;
    }

    public void SetGraphicsMedium()
    {
        DebugX.Log($"{LogClassName} : Graphics => Medium.", LogFilters.Analytics, gameObject);
        SelectedGraphicsLevel = 2;
    }

    public void SetGraphicsHigh()
    {
        DebugX.Log($"{LogClassName} : Graphics => High.", LogFilters.Analytics, gameObject);
        SelectedGraphicsLevel = 3;
    }
}