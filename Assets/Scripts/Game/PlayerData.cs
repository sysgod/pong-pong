using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public Vector4 BallColor;
    public float BallSize;
    public int HighScore;

    public PlayerData()
    {
        BallColor = Color.white;
        BallSize = 1;
        HighScore = 0;
    }
}
