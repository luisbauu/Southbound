using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class OptionsUI : MonoBehaviour
{
    public Button MainMenu;

    public Toggle Difficulty, Sound;

    //public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Difficulty") == 1)
        {
            Difficulty.isOn = true;
        }
        else
        {
            Difficulty.isOn = false;
        }

        if(PlayerPrefs.GetInt("Sound") == 1)
        {
            Sound.isOn = true;
        }
        else
        {
            Sound.isOn = false;
        }

        MainMenu.onClick.AddListener(MainMenuPressed);

        Difficulty.onValueChanged.AddListener(delegate{DifficultyToggled();});
        Sound.onValueChanged.AddListener(delegate{SoundToggled();});   
    }

    void MainMenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void DifficultyToggled()
    {
        int num;

        if(Difficulty.isOn)
        {
            num = 1;
        }
        else
        {
            num = 0;
        }

        PlayerPrefs.SetInt("Difficulty", num);
    }

    public void SoundToggled()
    {
        int num;

        if(Sound.isOn)
        {
            num = 1;
        }
        else
        {
            num = 0;
        }

        PlayerPrefs.SetInt("Sound", num);
    }

}
