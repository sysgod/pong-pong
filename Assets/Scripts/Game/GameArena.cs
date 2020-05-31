using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArena : MonoBehaviour
{
    [SerializeField] private Transform _player1SpawnPoint = null;
    [SerializeField] private Transform _player2SpawnPoint = null;

    [SerializeField] private Transform _leftBound;
    [SerializeField] private Transform _righthBound;

    public GameObject player1;
    public GameObject player2;

    public GameBall Ball;

    // Start is called before the first frame update
    void Start()
    {
        PrepareScene();
    }

    public void PrepareScene()
    {
        
        //SetupBounds
        var halfScreenWidth = Screen.width / 2f;
        var halfScreenHeight = Screen.height / 2f;

        var leftScreenPos = new Vector2(5, halfScreenHeight);
        var rightScreenPos = new Vector2(Screen.width-5, halfScreenHeight);

        var pl1ScreenPos = new Vector2(halfScreenWidth,Screen.height-260 );
        var pl2ScreenPos = new Vector2(halfScreenWidth,260);

        _leftBound.transform.position = Camera.main.ScreenToWorldPoint(leftScreenPos);
        _righthBound.transform.position = Camera.main.ScreenToWorldPoint(rightScreenPos);

        var refScale = GameController.Instance.Config.RefenceVerticalBoundsScale;
        var refScreenHeight = GameController.Instance.Config.ReferenceScreenHeight;

        var currentScale = Vector3.one;
        currentScale.y = refScale / refScreenHeight * Screen.height;
        _leftBound.transform.localScale = currentScale;
        _righthBound.transform.localScale = currentScale;


        _player1SpawnPoint.transform.position = Camera.main.ScreenToWorldPoint(pl1ScreenPos);
        _player2SpawnPoint.transform.position = Camera.main.ScreenToWorldPoint(pl2ScreenPos);


        if (GameController.Instance.IsSinglePlayerGameStarted)
        {
            player1 = Instantiate(GameController.Instance.Config.LocalPlayerPrefab, _player1SpawnPoint);
            player1.transform.localScale = Vector3.one;
            player1.transform.localPosition = Vector3.zero;

            player2 = Instantiate(GameController.Instance.Config.LocalPlayerPrefab, _player2SpawnPoint);
            player2.transform.localScale = Vector3.one;
            player2.transform.localPosition = Vector3.zero;
        }

        Ball.SetColor(GameController.Instance.GameData.BallColor);
        Ball.ResetBall();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
