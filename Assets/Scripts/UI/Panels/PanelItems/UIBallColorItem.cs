using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBallColorItem : MonoBehaviour
{
    public Image colorHolder;
    public UIBallSettingsPanel parent;

    public void Init(Color color,UIBallSettingsPanel parentPanel)
    {
        parent = parentPanel;
        colorHolder.color = color;
    }

    public void G_UpdateColor()
    {
        parent.SetColor(colorHolder.color);
    }
}
