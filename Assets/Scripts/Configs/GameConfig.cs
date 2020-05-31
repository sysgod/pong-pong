using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Game Configs/GlobalPongConfig", order = 1)]
public class GameConfig : ScriptableObject
{
    [Header("Global Settings")]
    public int Version = 0;

    public float ReferenceScreenHeight = 1440;
    public float RefenceVerticalBoundsScale = 30f;

    public GameObject LocalPlayerPrefab;

    [Space(10)]
    [Header("Ball Settings")]
    public Color[] BallColors;
    public float MinBallScale=1;
    public float MaxBallScale=4;
    public float MinBallVelocity = 2;
    public float MaxBallVelocity = 5;
    public float PaddleHitInActivityTime = 15f;

    [Space(10)]
    [Header("Game Scenes")]
    public string MenuScene = "MainMenu";
    public string GameScene = "pongpong";
}
