using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePanel : UIPanel
{
    public Text HighScoreText;
    public Text ScoreText;
    private PlayerData _playerData = null;

    public override void Hide()
    {
        UnSubscribeEvents();
        gameObject.SetActive(false);
    }



    public override void Show<T>(T obj)
    {
        _playerData = GameController.Instance.GameData;

        UpdateHighScore();
        UpdateScore();

        gameObject.SetActive(true);
        SubscribeEvents();
    }


    private void UpdateHighScore()
    {
        HighScoreText.text = ReplaceScoreTag(UIController.Instance.Config.HiScoreString, _playerData.HighScore);
    }

    private void UpdateScore()
    {
        ScoreText.text =  ReplaceScoreTag( UIController.Instance.Config.CurrentScoreString, GameController.Instance.CurrentScore);
    }

    private string ReplaceScoreTag(string inString,int scoreValue)
    {
        var str = inString;
        if (str.Contains("#score"))
        {
            str = str.Replace("#score", scoreValue.ToString());
        }
       return str;
    }

    public void G_ExitGame()
    {
        GameController.Instance.ExitGame();
    }

    private void SubscribeEvents()
    {
        GameController.Instance.OnScoreUpdated = () =>
        {
            UpdateScore();
        };

        GameController.Instance.OnHighScoreUpdated = () =>
        {
            UpdateHighScore();
        };
    }
    private void UnSubscribeEvents()
    {
        GameController.Instance.OnScoreUpdated = null;
       GameController.Instance.OnHighScoreUpdated = null;
    }
}
