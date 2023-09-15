using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsManager : SingletonBehaviour<GraphicsManager>
{
    private const string LogClassName = "GraphicsManager";

    public void SetGraphicsLow()
    {
        DebugX.Log($"{LogClassName} : Graphics => Low.", LogFilters.Analytics, gameObject);
    }

    public void SetGraphicsMedium()
    {
        DebugX.Log($"{LogClassName} : Graphics => Medium.", LogFilters.Analytics, gameObject);
    }

    public void SetGraphicsHigh()
    {
        DebugX.Log($"{LogClassName} : Graphics => High.", LogFilters.Analytics, gameObject);
    }
}