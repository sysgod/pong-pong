using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UIPanelCollectionData", menuName = "Game Configs/Global UI Config", order = 2)]

public class UserInterfaceConfig : ScriptableObject
{
    public enum UIPanleType
    {
        //Game Panel
        BallSettings = 0, // customisation
        MainMenu = 1,//main menu (permanent)
        GameMenu = 2,//in game menu (permanent)


        UNKNOWN = 65535 //used to avoid spawning if not needed
    }

    [System.Serializable]
    public class PanelTypeConfig
    {
        public UIPanleType Type;
        public UIPanel PanelPrefab;
    }

    [Header("Panels Strings")]
    public string HiScoreString = "Hi-Score : #score";
    public string CurrentScoreString = "Score : #score";

    [Space(5)]
    [Header("Panel Collection")]
    public PanelTypeConfig[] GamePanels;
}
