using UnityEngine;

public class PlayerData : MonoBehaviour
{
    GameManager gameManager;

    private float highScore = 0;

    private int coin = 0;
    private bool coinCollected = false;

    private int halfJump;
    private int doubleJump;
    private int skin;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        gameManager = FindObjectOfType<GameManager>();

        SetHighScore();
        SetCoin();

        CheckHalfJump();
        CheckDoubleJump();
        CheckSkin();

        PlayerPrefs.Save();
    }
    private void Update()
    {
        SaveHighScore();
        SaveCoin();
    }

    private void CheckSkin()
    {
        if (!PlayerPrefs.HasKey(nameof(skin)))
        {
            PlayerPrefs.SetInt(nameof(skin), 0);
        }
        else
        {
            skin = PlayerPrefs.GetInt(nameof(skin));
        }
    }
    private void CheckHalfJump()
    {
        if (!PlayerPrefs.HasKey(nameof(halfJump)))
        {
            PlayerPrefs.SetInt(nameof(halfJump), 0);
        }
        else
        {
            halfJump = PlayerPrefs.GetInt(nameof(halfJump));
        }
    }
    private void CheckDoubleJump()
    {
        if (!PlayerPrefs.HasKey(nameof(doubleJump)))
        {
            PlayerPrefs.SetInt(nameof(doubleJump), 0);
        }
        else
        {
            doubleJump = PlayerPrefs.GetInt(nameof(doubleJump));
        }
    }


    private void SetCoin()
    {
        if (!PlayerPrefs.HasKey(nameof(coin)))
        {
            PlayerPrefs.SetInt(nameof(coin), coin);
        }
        else
        {
            coin = PlayerPrefs.GetInt(nameof(coin));
        }
    }
    private void SetHighScore()
    {
        //Bu kod, eðer highscore diye bir playerpref kayýtlý deðilse kaydeder, kayýtlýysa alýr
        if (!PlayerPrefs.HasKey(nameof(highScore)))
        {
            PlayerPrefs.SetFloat(nameof(highScore), highScore);
        }
        else
        {
            highScore = PlayerPrefs.GetFloat(nameof(highScore));
        }
    }


    void SaveHighScore()
    {
        if (gameManager.skor > highScore)
        {
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
        PlayerPrefs.SetInt(nameof(coin), coin);
        PlayerPrefs.Save();
        coinCollected = true;
    }

}
