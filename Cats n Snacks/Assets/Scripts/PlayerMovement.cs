using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hareket : MonoBehaviour
{
    [SerializeField] float yatayHiz = 5;
    [SerializeField] float dikeyYon = 10;
    [SerializeField] LayerMask ziplamaKontrol;
    bool yerdeMi = true;

    Animator animasyonDurumu;
    SpriteRenderer hareketYonu;
    Rigidbody2D rb;
    BoxCollider2D carpma;
    float yatayYon = 0;


    [SerializeField] AudioClip ziplamaSesi; 
    [SerializeField] AudioClip olmeSesi;

    private AudioSource sesKaynagi;



    void Start()
    {
        animasyonDurumu = this.GetComponent<Animator>();
        hareketYonu = this.GetComponent<SpriteRenderer>();
        rb = this.GetComponent<Rigidbody2D>();
        carpma = this.GetComponent<BoxCollider2D>();
        sesKaynagi = GetComponent<AudioSource>();
    }


    void Update()
    {
        yatayYon = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(yatayYon * yatayHiz, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && yerdeMi == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, dikeyYon);
            sesKaynagi.PlayOneShot(ziplamaSesi);
        }


        if (Physics2D.BoxCast(carpma.bounds.center, carpma.bounds.size, 0, Vector2.down, 0.1f, ziplamaKontrol))
        {
            yerdeMi = true;
        }
        else
        {
            yerdeMi = false;
        }

        AnimasyonGuncelle();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tuzak")
        {
            animasyonDurumu.SetBool("OlduMu", true);
            rb.simulated = false;

            Invoke("Oldur", 1f);
            sesKaynagi.PlayOneShot(olmeSesi);
        }
    }


    private void Oldur()
    {
        gameObject.SetActive(false);
        Invoke("OlumScene", 1.5f);
    }


    void OlumScene()
    {
        SceneManager.LoadScene("Olum");
    }


    private void AnimasyonGuncelle()
    {
        /* durumun sayýsal deðeri:
         * 0 = bekleme
         * 1 = koþma
         * 2 = zýplama
         * 3 = düþme */


        float dikeyHiz = rb.velocity.y;

        if (yatayYon < 0 && rb.simulated == true)
        {
            hareketYonu.flipX = true;
        }
        else if (yatayYon > 0 && rb.simulated == true)
        {
            hareketYonu.flipX = false;
        }

        if (yerdeMi == false)
        {
            if (dikeyHiz > 0.1)
            {
                animasyonDurumu.SetInteger("durum", 2);
            }
            else
              if (dikeyHiz < -0.1)
            {
                animasyonDurumu.SetInteger("durum", 3);
            }
            //else
            //{
            //    animasyonDurumu.SetInteger("durum", 0);
            //}
        }
        else
        {
            if (yatayYon == 0)
            {
                animasyonDurumu.SetInteger("durum", 0);
            }
            else
            {
                animasyonDurumu.SetInteger("durum", 1);
            }
        }

    }
}
