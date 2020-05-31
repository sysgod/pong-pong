using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScoreOnHit : MonoBehaviour
{
    public int score = 10;
    public string colliderTag = "Player";
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(colliderTag))
            GameController.Instance.AddScore(score);
    }
}
