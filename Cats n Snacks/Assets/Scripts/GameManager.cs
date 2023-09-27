using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float engelSpeed = 10f;
    [SerializeField] float maxSpeed = 20f; // Belki 30 civar�na �ekilebilir

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
    public float coinSkor = 0f;
    #endregion

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
        //Bu kod her 100 skorda bir engel h�z�n� ve skor artma h�z�n� artt�r�r.
        if (scaleCompleted == false && skorSorgusu <= skor)
        {

            skorSorgusu += 100f;
            engelSpeed += 0.25f;
            skorScale += 1f;

            if (engelSpeed >= maxSpeed)//Bu if blo�u, engellerin max h�za ula�mas�n� sa�lar
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
