using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScoreCoin : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI scoreText;

    float currentCoin;
    float currentScore;
    void Start()
    {
        //PlayerPrefs.SetFloat("coin", 0.00f);
        //PlayerPrefs.SetFloat("highScore", 0.00f);

        currentCoin = PlayerPrefs.GetInt("coin");
        currentScore = (int)PlayerPrefs.GetFloat("highScore");
        

        coinText.text = "Coins: " + currentCoin.ToString();
        scoreText.text = "High Score: " + currentScore.ToString();
    }

    private void Update()
    {
        currentCoin = PlayerPrefs.GetInt("coin");
        currentScore = (int)PlayerPrefs.GetFloat("highScore");


        coinText.text = "Coins: " + currentCoin.ToString();
        scoreText.text = "High Score: " + currentScore.ToString();
    }
}
