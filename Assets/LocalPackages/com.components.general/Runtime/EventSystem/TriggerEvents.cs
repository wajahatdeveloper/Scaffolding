using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    public bool debug;

#if UNITY_EDITOR
    [ValueDropdown(nameof(GetAllTags))]
#endif
    public List<string> TriggerTags;

    public LayerMask layer;

    public UnityEvent<Collider> OnTriggerEnterEvent;
    public UnityEvent OnTriggerExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (!TriggerTags.Contains(other.tag)) return;
        if (( layer & (1 << other.gameObject.layer)) == 0) return;
        
        if (debug)
        {
            print("this.name " + name);
            print("other.name " + other.name);
            print("other.tag " + other.tag);
        }

        OnTriggerEnterEvent?.Invoke(other);
    }

#if UNITY_EDITOR
    private string[] GetAllTags()
    {
        return UnityEditorInternal.InternalEditorUtility.tags;
    }
#endif

    private void OnTriggerExit(Collider other)
    {
        if (TriggerTags.Contains(other.tag))
            OnTriggerExitEvent?.Invoke();
    }
}