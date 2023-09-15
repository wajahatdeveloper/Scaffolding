﻿#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ExtendedButtons
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    public class ListenerSingleton : MonoBehaviour
    {
        private static IButtonsListener _instance;

        [RuntimeInitializeOnLoadMethod]
        static void CreateInstance()
        {
            if (_instance == null)
            {
                _instance = (IButtonsListener)FindObjectOfType(typeof(ButtonsListenerMono));
                if (_instance == null)
                {
                    var singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<ButtonsListenerBasic>();
                    singletonObject.name = typeof(ButtonsListenerBasic).ToString() + " (Singleton)";
                }
            }
        }
    }
}
