using UnityEngine.UI;

public class UIMainMenuPanel : UIPanel {

    public Text highScore;
    private PlayerData _playerData;
    
    public override void Show<T>(T obj)
    {
        _playerData = GameController.Instance.GameData;

        var str = UIController.Instance.Config.HiScoreString;
        if (str.Contains("#score"))
        {
            str = str.Replace("#score", _playerData.HighScore.ToString());
        }

        highScore.text = str;

        gameObject.SetActive(true);
    }

    public override void Hide()
    {
        base.Hide();
    }

    public void G_ShowBallSetting()
    {
        UIController.Instance.ShowPanelOfType(UserInterfaceConfig.UIPanleType.BallSettings,GameController.Instance.GameData);
    }

    public void G_LoadGameScene()
    {
        GameController.Instance.StartSinglePlayerGame();
    }
}
    
