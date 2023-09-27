using UnityEngine;

public class CoinManager : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("YesilMama"))
            {
                gameManager.coinSkor++;
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("MaviMama"))
            {
                gameManager.coinSkor += 10;
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("KirmiziMama"))
            {
                gameManager.coinSkor += 50;
                Destroy(gameObject);
            }
        }
    }
}
