using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hareket : MonoBehaviour
{
    [SerializeField] float yatayHiz = 5;
    [SerializeField] float dikeyYon = 10;
    [SerializeField] float olumDususHizi = 5;

    [SerializeField] LayerMask ziplamaKontrol;

    bool yerdeMi = true;
    bool olduMu = false;

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


        if (Input.GetKey(KeyCode.Space) && rb.velocity.y < 0.1f && yerdeMi == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, dikeyYon);
            sesKaynagi.PlayOneShot(ziplamaSesi);
        }
        
        ZeminSorgusu();

        OlmusseYereDusur();

        AnimasyonGuncelle();
    }

    private void OlmusseYereDusur()
    {
        if(olduMu == true && yerdeMi == true)
        {
            rb.simulated = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tuzak")
        {
            animasyonDurumu.SetBool("OlduMu", true);

            olduMu = true;



            Invoke("Oldur", 1f);
            sesKaynagi.PlayOneShot(olmeSesi);
        }
    }

    private void ZeminSorgusu()
    {
        if (Physics2D.BoxCast(carpma.bounds.center, carpma.bounds.size, 0, Vector2.down, 0.1f, ziplamaKontrol))
        {
            yerdeMi = true;
        }
        else
        {
            yerdeMi = false;
        }
    }

    private void Oldur()
    {
        gameObject.SetActive(false);
        Invoke("OlumScene", 1.5f);
    }


    void OlumScene()
    {
        SceneManager.LoadScene(0);
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
            else if (dikeyHiz < -0.1)
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
                animasyonDurumu.SetInteger("durum", 0);


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
