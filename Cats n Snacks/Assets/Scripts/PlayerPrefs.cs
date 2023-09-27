using UnityEngine;

public class PlayerData : MonoBehaviour
{
    GameManager gameManager;

    private float highScore = 0;

    private float coin = 0;
    private bool coinCollected = false;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        gameManager = FindObjectOfType<GameManager>();

        SetHighScore();
        SetCoin();

        PlayerPrefs.Save();
    }
    private void Update()
    {
        SaveHighScore();
        SaveCoin();
    }

    private void SetCoin()
    {
        if (!PlayerPrefs.HasKey(nameof(coin)))
        {
            PlayerPrefs.SetFloat(nameof(coin), coin);

            Debug.Log("Current Coin: " + coin);
        }
        else
        {
            coin = PlayerPrefs.GetFloat(nameof(coin));

            Debug.Log("(else)Current Coin: " + coin);
        }
    }

    private void SetHighScore()
    {
        if (!PlayerPrefs.HasKey(nameof(highScore)))
        {
            PlayerPrefs.SetFloat(nameof(highScore), highScore);

            Debug.Log("High Score: " + highScore);
        }
        else
        {
            highScore = PlayerPrefs.GetFloat(nameof(highScore));

            Debug.Log("(else)High Score: " + highScore);
        }
    }

    void SaveHighScore()
    {
        if (gameManager.skor > highScore)
        {
            Debug.Log("High Score!!!");
            gameManager.skorText.color = Color.red;

            highScore = gameManager.skor;
            PlayerPrefs.SetFloat(nameof(highScore), highScore);
            PlayerPrefs.Save();
        }
    }

    void SaveCoin()
    {
        if (gameManager.isDeath == false) { return; }//Oyuncu ölmediyse return et
        if (coinCollected == true) { return; }//coinler kaydedildiyse return et

        coin += gameManager.coinSkor;
        PlayerPrefs.SetFloat(nameof(coin), coin);
        PlayerPrefs.Save();

        Debug.Log("Current Coin: " + coin);
        coinCollected = true;

    }

}
