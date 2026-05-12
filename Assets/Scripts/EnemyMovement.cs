using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float leftLimit = -2f;
    public float rightLimit = 2f;

    private int direction = 1;

    Animator animator;

    public GameObject player;

    void Start()
{
    animator = GetComponent<Animator>();
}

    void Update()
    {
        // Movimiento horizontal
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

        // Cambiar dirección al llegar a los límites
        if (transform.position.x >= rightLimit)
        {
            direction = -1;
            Flip();
        }
        else if (transform.position.x <= leftLimit)
        {
            direction = 1;
            Flip();
        }

        animator.SetFloat("Speed", Mathf.Abs(speed));
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnCollisionEnter2D()
    {
        player.GetComponent<CharacterControllerTransform>(). lifes -= 1;
    }
}
