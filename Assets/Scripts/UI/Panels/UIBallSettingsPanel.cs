using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBallSettingsPanel : UIPanel
{
    public UIBallColorItem ColorItemPrefab;
    public RectTransform ColorPickRoot;
    public Image ballPreview;

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

 
    public override void Show<T>(T obj)
    {
        ballPreview.color = GameController.Instance.GameData.BallColor;
        CreateColorPickItems();
        gameObject.SetActive(true);
    }

    private void ClearColors()
    {
        foreach(Transform t in ColorPickRoot)
        {
            GameObject.Destroy(t.gameObject);
        }
    }
    private void CreateColorPickItems()
    {
        ClearColors();
        var colors = GameController.Instance.Config.BallColors;
        for(int i = 0; i < colors.Length; i++)
        {
            var item = Instantiate(ColorItemPrefab, ColorPickRoot);
            item.transform.localScale = Vector3.one;

            item.Init(colors[i],this);
        }
    }

    public void SetColor(Color color)
    {
        ballPreview.color = color;
    }

    public void G_Confirm()
    {
        GameController.Instance.GameData.BallColor = ballPreview.color;
        GameController.Instance.SaveGameData();
        Hide();
    }

    public void G_Cancel()
    {
        Hide();
    }
}
