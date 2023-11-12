using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject panelPause;

    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public void PauseGame()
    {
        audioSource.PlayOneShot(audioClips[0]);

        panelPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        audioSource.PlayOneShot(audioClips[0]);

        panelPause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMainMenu()
    {
        audioSource.PlayOneShot(audioClips[0]);
        
        SceneManager.LoadScene("MainMenu");
    }
}
