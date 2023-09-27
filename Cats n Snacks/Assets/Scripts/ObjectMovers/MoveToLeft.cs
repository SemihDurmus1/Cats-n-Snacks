using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLeft : MonoBehaviour
{
    GameManager gameManager;

    public float moveSpeed;

    private Rigidbody2D rb;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();//New Object yapmak yerin bu kod koyulmalý

        moveSpeed = gameManager.engelSpeed;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(-moveSpeed, 0f, 0f);

    }
}
