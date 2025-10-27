using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Sprite[] walkFrames; // asigna los 5 frames en el inspector
    public float frameRate = 0.2f; // segundos por frame

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 movement;
    private int frameIndex = 0;
    private float frameTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = walkFrames[0];
        movement = Vector2.zero;

        // Forzar cero absoluto
        Input.ResetInputAxes();
    }


    void Update()
    {
        // Leer input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Evitar input fantasma
        if (Mathf.Abs(horizontal) < 0.01f) horizontal = 0f;
        if (Mathf.Abs(vertical) < 0.01f) vertical = 0f;

        movement.x = horizontal;
        movement.y = vertical;

        // Evitar movimiento diagonal
        if (movement.x != 0) movement.y = 0;

        // Animación
        if (movement != Vector2.zero)
        {
            frameTimer += Time.deltaTime;
            if (frameTimer >= frameRate)
            {
                frameTimer = 0f;
                frameIndex = (frameIndex + 1) % walkFrames.Length;
                sr.sprite = walkFrames[frameIndex];
            }
            sr.flipX = movement.x > 0;
        }
        else
        {
            sr.sprite = walkFrames[0];
            frameIndex = 0;
            frameTimer = 0f;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
