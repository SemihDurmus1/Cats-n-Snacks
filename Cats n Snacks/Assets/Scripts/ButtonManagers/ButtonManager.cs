using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject panelPause;

    public void PauseGame()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
