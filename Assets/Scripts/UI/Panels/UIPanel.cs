using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour, IPanel
{
    public virtual void Hide()
    {
        
    }

    public bool IsShown()
    {
        return gameObject.activeInHierarchy;
    }

    public virtual void Show<T>(T obj)
    {
        gameObject.SetActive(true);
    }
}
