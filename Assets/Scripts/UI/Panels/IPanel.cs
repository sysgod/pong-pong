using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPanel
{
    bool IsShown();
    void Show<T>(T obj);
    void Hide();
}
