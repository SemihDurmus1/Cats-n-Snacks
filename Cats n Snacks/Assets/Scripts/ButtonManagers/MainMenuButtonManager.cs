using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonManager : MonoBehaviour
{
    public GameObject panelStore;
    public GameObject catStore;

    public Button halfJump;
    public Button doubleJump;
    public Button orangeCat;
    public Button grayCat;

    public AudioClip[] sounds;
    private AudioSource sesKaynagi;

    private Image orangeActiveImage;
    private Image grayActiveImage;

    public Sprite collectedSprite;

    private readonly int halfJumpAmount = 100;
    private readonly int doubleJumpAmount = 100;
    private readonly int skinAmount = 100;

    private void Start()
    {
        sesKaynagi = GetComponent<AudioSource>();

        HalfJumpCheckActive();
        DoubleJumpCheckActive();
        Skin2CheckActive();
        Debug.Log(PlayerPrefs.GetInt("skin"));

        grayActiveImage = grayCat.transform.Find("aktif").GetComponent<Image>();
        orangeActiveImage = orangeCat.transform.Find("aktif").GetComponent<Image>();
    }

    private void HalfJumpCheckActive()
    {
        if (PlayerPrefs.GetInt("halfJump") == 1)
        {
            halfJump.interactable = false;
            Image halfJumpImage = halfJump.transform.Find("Kilit").GetComponent<Image>();
            halfJumpImage.sprite = collectedSprite;
        }
    }
    private void DoubleJumpCheckActive()
    {
        if (PlayerPrefs.GetInt("doubleJump") == 1)
        {
            doubleJump.interactable = false;
            Image doubleJumpImage = doubleJump.transform.Find("Kilit").GetComponent<Image>();
            doubleJumpImage.sprite = collectedSprite;
        }
    }
    private void Skin2CheckActive()
    {
        if (PlayerPrefs.GetInt("skin") == 1)
        {
            Image kilitImage = orangeCat.transform.Find("Kilit").GetComponent<Image>();
            orangeActiveImage = orangeCat.transform.Find("aktif").GetComponent<Image>();
            kilitImage.sprite = collectedSprite;
            orangeActiveImage.gameObject.SetActive(true);
            grayActiveImage.gameObject.SetActive(false);
        }
        else
        {
            try
            {
                orangeActiveImage.gameObject.SetActive(false);
                grayActiveImage.gameObject.SetActive(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }


    public void StartGame()
    {
        sesKaynagi.PlayOneShot(sounds[0]);

        SceneManager.LoadScene("Main");
    }


    public void OpenStore()
    {
        panelStore.SetActive(true);
        sesKaynagi.PlayOneShot(sounds[0]);
    }
    public void CloseStore()
    {
        panelStore.SetActive(false);
        sesKaynagi.PlayOneShot(sounds[0]);
    }
    public void OpenCats()
    {
        catStore.SetActive(true);
        sesKaynagi.PlayOneShot(sounds[0]);
    }
    public void CloseCats() 
    {
        catStore.SetActive(false);
        sesKaynagi.PlayOneShot(sounds[0]);
    }


    public void UnlockHalfJump()
    {
        if (PlayerPrefs.GetInt("coin") >= halfJumpAmount)
        {
            sesKaynagi.PlayOneShot(sounds[2]);
            int currentCoinSkor = PlayerPrefs.GetInt("coin");
            Debug.Log("Old coin: " + currentCoinSkor);

            currentCoinSkor -= halfJumpAmount;
            PlayerPrefs.SetInt("coin", currentCoinSkor);
            Debug.Log("New coin: " + currentCoinSkor);

            PlayerPrefs.SetInt("halfJump", 1);
        }
        else
        {
            sesKaynagi.PlayOneShot(sounds[1]);
            Debug.Log("Yetersiz Para");
        }
        HalfJumpCheckActive();
    }
    public void UnlockDoubleJump()
    {
        if (PlayerPrefs.GetInt("coin") >= doubleJumpAmount)
        {
            sesKaynagi.PlayOneShot(sounds[2]);

            int currentCoinSkor = PlayerPrefs.GetInt("coin");
            Debug.Log("Old coin: " + currentCoinSkor);

            currentCoinSkor -= doubleJumpAmount;
            PlayerPrefs.SetInt("coin", currentCoinSkor);
            Debug.Log("New coin: " + currentCoinSkor);

            PlayerPrefs.SetInt("doubleJump", 1);
        }
        else
        {
            sesKaynagi.PlayOneShot(sounds[1]);
            Debug.Log("Yetersiz Para");
        }
        DoubleJumpCheckActive();
    }
    public void UnlockSkin2()
    {
        if (PlayerPrefs.GetInt("unlockSkin") == 1)
        {
            sesKaynagi.PlayOneShot(sounds[2]);

            PlayerPrefs.SetInt("skin", 1);
        }
        else if (PlayerPrefs.GetInt("coin") >= skinAmount)
        {
            sesKaynagi.PlayOneShot(sounds[2]);

            int currentCoinSkor = PlayerPrefs.GetInt("coin");
            Debug.Log("Old coin: " + currentCoinSkor);

            currentCoinSkor -= skinAmount;
            PlayerPrefs.SetInt("coin", currentCoinSkor);
            Debug.Log("New coin: " + currentCoinSkor);
            Debug.Log("Skin alýndý");

            PlayerPrefs.SetInt("skin", 1);
            PlayerPrefs.SetInt("unlockSkin", 1);
        }
        else
        {
            sesKaynagi.PlayOneShot(sounds[1]);
            Debug.Log("Yetersiz Para");
        }
        Skin2CheckActive();
    }

    public void ActivateSkin1()
    {
        sesKaynagi.PlayOneShot(sounds[2]);

        grayActiveImage = grayCat.transform.Find("aktif").GetComponent<Image>();
        grayActiveImage.gameObject.SetActive(true);

        PlayerPrefs.SetInt("skin", 0);

        Skin2CheckActive();
    }
}
