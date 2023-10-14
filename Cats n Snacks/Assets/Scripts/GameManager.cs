using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Animator player;

    [SerializeField] RuntimeAnimatorController orangeCatController;

    public float engelSpeed = 10f;
    [SerializeField] float maxSpeed = 20f;

    public bool isDeath = false;

    #region SkorManager
    public TextMeshProUGUI skorText;

    public float skor = 0f;

    private float skorSorgusu = 100f;//Her 100 skorda bir 100 artar
    private float skorScale = 10f;

    private bool scaleCompleted = false;
    #endregion

    #region CoinSkor
    public TextMeshProUGUI coinSkorText;
    public int coinSkor = 0;
    #endregion

    [SerializeField] Button halfJumpButton;
    [SerializeField] Button doubleJumpButton;

    private void Start()
    {
        if (Time.timeScale != 1) { Time.timeScale = 1; }

        HalfJumpCheckActive();
        DoubleJumpCheckActive();
        Skin2CheckActive();
    }

    private void HalfJumpCheckActive()
    {
        if (PlayerPrefs.GetInt("halfJump") != 1)
        {
            halfJumpButton.interactable = false;
        }
        else if (PlayerPrefs.GetInt("halfJump") == 1)
        {
            halfJumpButton.interactable = true;
        }
    }
    private void DoubleJumpCheckActive()
    {
        if (PlayerPrefs.GetInt("doubleJump") != 1)
        {
            doubleJumpButton.interactable = false;
        }
        else if (PlayerPrefs.GetInt("doubleJump") == 1)
        {
            doubleJumpButton.interactable = true;
        }
    }
    private void Skin2CheckActive()
    {
        if (PlayerPrefs.GetInt("skin") == 1)
        {
            player.runtimeAnimatorController = orangeCatController;
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null) 
        {
            isDeath = true;
            //Time.timeScale = 0f;
            return;
        }

        SkorYaz();

        CoinSkorYaz();

        OyunuHizlandir();

    }

    private void OyunuHizlandir()
    {
        //Bu kod her 100 skorda bir engel hýzýný ve skor artma hýzýný arttýrýr.
        if (scaleCompleted == false && skorSorgusu <= skor)
        {

            skorSorgusu += 100f;
            engelSpeed += 0.25f;
            skorScale += 1f;

            if (engelSpeed >= maxSpeed)//Bu if bloðu, engellerin max hýza ulaþmasýný saðlar
            {
                scaleCompleted = true;
            }
        }
    }

    private void SkorYaz()
    {
        //Skoru ekrana yazmaya yarar
        skor += skorScale * Time.deltaTime;
        skorText.text = ((int)skor).ToString("0000");
    }

    private void CoinSkorYaz()
    {
        coinSkorText.text = ((int)coinSkor).ToString();
    }

}
