using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameConfig _config;
    public GameConfig Config { get { return _config; } }
    // Start is called before the first frame update
    public static GameController Instance;

    private PlayerData _gameData;
    public PlayerData GameData { get { return _gameData; } }
    public bool IsPlayerNew { get; set; }

    //Something for arena controller setup
    public bool IsSinglePlayerGameStarted { get; set; }
    public bool IsMultiplayerGameStarted { get { return !IsSinglePlayerGameStarted; } }
    public int CurrentScore {  get;set; }

    //Some Events
    public System.Action OnPlayerDataLoaded = null;
    public System.Action OnScoreUpdated = null;
    public System.Action OnHighScoreUpdated = null;
   
    public void LoadGameData()
    {
        var json = PlayerPrefs.GetString($"playerProfile_{_config.Version}");
        if (string.IsNullOrEmpty(json))
        {
            //create new
            _gameData = new PlayerData();
            _gameData.BallColor = Color.white;
            _gameData.BallSize = _config.MinBallScale;

            //Save with inials from config
            SaveGameData();

            IsPlayerNew = true;
        }
        else
        {
            //load existed
            _gameData = JsonUtility.FromJson<PlayerData>(json);
            IsPlayerNew = false;
        }

        if (OnPlayerDataLoaded != null)
        {
            OnPlayerDataLoaded();
        }
    }

    public void StartSinglePlayerGame()
    {
        CurrentScore = 0;
        IsSinglePlayerGameStarted = true;
        SceneManager.LoadScene(GameController.Instance.Config.GameScene);
    }

    public void ExitGame()
    {
        SaveGameData();
        IsSinglePlayerGameStarted = false;
        SceneManager.LoadScene(GameController.Instance.Config.MenuScene);
    }

    public void SaveGameData()
    {
        var json = JsonUtility.ToJson(_gameData);
        PlayerPrefs.SetString($"playerProfile_{_config.Version}",json);
    }

    public void AddScore(int score)
    {
        CurrentScore += score;
        OnScoreUpdated();

        if (CurrentScore > _gameData.HighScore)
        {
            _gameData.HighScore = CurrentScore;
            OnHighScoreUpdated();
        }
      
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }
}
