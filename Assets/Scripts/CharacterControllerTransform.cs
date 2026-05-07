using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerTransform : MonoBehaviour
{
    public float speed = 5.0f;
    bool facingRight = true;

    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;

    Animator animator;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float speedValue = Mathf.Abs(horizontal);

        animator.SetFloat("Speed", speedValue);

        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        transform.position = position;

        if (horizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontal < 0 && facingRight)
        {
            Flip();
        }

        if (speedValue == 0)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying)
        audioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
