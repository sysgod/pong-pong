using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBall : MonoBehaviour
{

    public Rigidbody2D Body;
    public SpriteRenderer SpriteRender;
    private float _lastTimeHitsPaddle;


    public void SetColor(Color c)
    {
        SpriteRender.color = c;
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        var topPoint = (Vector2) Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height));
        var bottomPoint = (Vector2) Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

        Vector2 point = UnityEngine.Random.insideUnitCircle * 5f;
        var p = point + topPoint;
        var p1 = point + bottomPoint;
        var dir = UnityEngine.Random.Range(0,100) > 50 ? p - (Vector2)transform.position : p1 - (Vector2)transform.position;
        dir.Normalize();

        var velRnd = UnityEngine.Random.Range(GameController.Instance.Config.MinBallVelocity, GameController.Instance.Config.MaxBallVelocity);
        var vel = dir.normalized * velRnd;
        Body.velocity = vel;

        _lastTimeHitsPaddle = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        if(pos.y>Screen.height + transform.localScale.x / 2 || pos.y < -transform.localScale.x / 2)
        {
            //Set Random Color And Scale
            RandomizeBall();
            ResetBall();
        }

        if((Time.time - _lastTimeHitsPaddle) >= GameController.Instance.Config.PaddleHitInActivityTime)
        {
            ResetBall();
        }
    }

    private void RandomizeBall()
    {
        var col = GameController.Instance.Config.BallColors[UnityEngine.Random.Range(0, GameController.Instance.Config.BallColors.Length)];
        SetColor(col);

        var scale = UnityEngine.Random.Range(GameController.Instance.Config.MinBallScale, GameController.Instance.Config.MaxBallScale);
        transform.localScale = Vector3.one * scale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
                        _lastTimeHitsPaddle = Time.time;
    }
}
