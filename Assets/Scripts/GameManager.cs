using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    
    int coinsThisSession;
    public static GameManager instance;

    private GameObject player;

    public Text coinsText;
    public Text distanceText;
    
    private int distance;

    // void Awake()
	// {
	// 	if (instance != null)
	// 	{
	// 		Destroy(gameObject);
	// 	}
	// 	else
	// 	{
	// 		instance = this;
	// 		DontDestroyOnLoad(gameObject);
	// 	}

	// }
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        coinsThisSession = 0;
        coinsText.text = "0";
        player = GameObject.Find("Player");

    }

    public void IncrementScore(string coinType)
    {
        if(coinType == "One")
        {
            coinsThisSession++;
            coinsText.text = coinsThisSession + " ";
        }
        else if(coinType == "Five")
        {
            coinsThisSession += 5;
            coinsText.text = coinsThisSession + " ";
        }
        else
        {
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        distance = Mathf.RoundToInt(player.transform.position.z) / 10;
        distanceText.text = distance.ToString() + " m";
    }

    public float TotalCoins()
    {
        return coinsThisSession;
    }

    public float TotalDistance()
    {
        return distance;
    }
}
