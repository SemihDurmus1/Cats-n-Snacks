using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hareket : MonoBehaviour
{
    [SerializeField] float dikeyYon = 10;
    [SerializeField] float halfJumpAmount = 16f;

    [SerializeField] LayerMask ziplamaKontrol;

    bool doubleJumped = false;
    bool yerdeMi = true;
    bool olduMu = false;

    Animator animasyonDurumu;
    Rigidbody2D rb;
    BoxCollider2D carpma;

    
    [SerializeField] AudioClip normalJump;
    [SerializeField] AudioClip halfJump;
    [SerializeField] AudioClip doubleJump;
    [SerializeField] AudioClip olmeSesi;

    [SerializeField] AudioClip yesilMama;
    [SerializeField] AudioClip maviMama;
    [SerializeField] AudioClip kirmiziMama;

    private AudioSource sesKaynagi;

    void Start()
    {
        animasyonDurumu = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        carpma = this.GetComponent<BoxCollider2D>();
        sesKaynagi = GetComponent<AudioSource>();
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.Space) && rb.velocity.y < 0.1f && yerdeMi == true)
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, dikeyYon);
        //    sesKaynagi.PlayOneShot(ziplamaSesi);
        //}
        
        ZeminSorgusu();

        OlmusseYereDusur();

        AnimasyonGuncelle();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tuzak"))
        {
            sesKaynagi.PlayOneShot(olmeSesi);

            animasyonDurumu.SetBool("OlduMu", true);

            olduMu = true;

            Invoke(nameof(Oldur), 1f);
        }
        else if (collision.CompareTag("YesilMama"))
        {
            sesKaynagi.PlayOneShot(yesilMama);
        }
        else if (collision.CompareTag("MaviMama"))
        {
            sesKaynagi.PlayOneShot(maviMama);
        }
        else if (collision.CompareTag("KirmiziMama"))
        {
            sesKaynagi.PlayOneShot(kirmiziMama);
        }
    }

    private void OlmusseYereDusur()
    {
        if(olduMu == true && yerdeMi == true)
        {
            rb.simulated = false;
        }
    }
    private void ZeminSorgusu()
    {
        if (Physics2D.BoxCast(carpma.bounds.center, carpma.bounds.size, 0, Vector2.down, 0.1f, ziplamaKontrol))
        {
            yerdeMi = true;
            doubleJumped = false;
        }
        else
        {
            yerdeMi = false;
        }
    }


    private void Oldur()
    {
        gameObject.SetActive(false);
        Invoke(nameof(LoadOlumScene), 1.5f);
    }
    void LoadOlumScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void AnimasyonGuncelle()
    {
        /* durumun sayýsal deðeri:
         * 0 = bekleme
         * 1 = koþma
         * 2 = zýplama
         * 3 = düþme */

        if (olduMu == true)
        {
            animasyonDurumu.SetBool("OlduMu",true);
            return;
        }

        float dikeyHiz = rb.velocity.y;

        if (yerdeMi == false)
        {
            if (dikeyHiz > 0.1)
            {
                animasyonDurumu.SetInteger("durum", 2);
            }
            else if (dikeyHiz < -0.1)
            {
                animasyonDurumu.SetInteger("durum", 3);
            }
        }
        else
        {
            animasyonDurumu.SetInteger("durum", 0);
        }
    }


    public void HalfJump()
    {
        if (rb.velocity.y < 0.1f && yerdeMi == true && olduMu == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, halfJumpAmount);
            sesKaynagi.PlayOneShot(halfJump);
        }
    }
    public void NormalJump()
    {
        if (yerdeMi && olduMu == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, dikeyYon);
            sesKaynagi.PlayOneShot(normalJump);
        }
    }
    public void DoubleJump()
    {
        if (doubleJumped == false && yerdeMi == false && olduMu == false)
        {
            doubleJumped = true;
            rb.velocity = new Vector2(rb.velocity.x, halfJumpAmount);
            sesKaynagi.PlayOneShot(doubleJump);
        }
    }
}
