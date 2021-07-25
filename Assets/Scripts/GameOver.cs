using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI FinalScore;
    private int oldCoins, newCoins;

    private int currentDistance, newDistance;
    public void Setup()
    {
        gameObject.SetActive(true);
        

        oldCoins = PlayerPrefs.GetInt("TotalCoins");
        newCoins = oldCoins + (int) GameManager.instance.TotalCoins();
        PlayerPrefs.SetInt("TotalCoins", newCoins);

        currentDistance = (int) GameManager.instance.TotalDistance();
        if(currentDistance > PlayerPrefs.GetInt("HighDistance"))
        {   
            PlayerPrefs.SetInt("HighDistance",currentDistance);
            FinalScore.text = "You have gathered " + GameManager.instance.TotalCoins() + " coins and \nTraversed " 
            + GameManager.instance.TotalDistance() + " m!\n\n|| PERSONAL BEST ||" ;
        }
        else
        {
            FinalScore.text = "You have gathered " + GameManager.instance.TotalCoins() + " coins and \nTraversed " 
            + GameManager.instance.TotalDistance() + " m!"; 
        }

    }

    public void RestartButton()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
