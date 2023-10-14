using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(-moveSpeed, 0f, 0f);
    }
}
