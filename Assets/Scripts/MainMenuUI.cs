using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public Button MainGame, Options;
    public int coins;
    public TextMeshProUGUI coinsText, distanceText;

    SceneLoader sceneLoader;
    // Start is called before the first frame update
    //public bool music, sound, difficulty;
    void Start()
    {
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
        MainGame.onClick.AddListener(MainGamePressed);
        Options.onClick.AddListener(OptionsPressed);
        coinsText.SetText(" : " + PlayerPrefs.GetInt("TotalCoins"));

        distanceText.SetText("Farthest Distance : " + PlayerPrefs.GetInt("HighDistance") + "m");
    }

    void MainGamePressed() 
    {
        sceneLoader.transitionNextScene("MainGame");
    }

    void OptionsPressed()
    {
        sceneLoader.transitionNextScene("Options");
    }
}

