using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimplestLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GameController.Instance.OnPlayerDataLoaded = () =>
        {
            SceneManager.LoadScene(GameController.Instance.Config.MenuScene);
        };

        GameController.Instance.LoadGameData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
