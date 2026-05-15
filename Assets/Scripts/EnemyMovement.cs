using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float leftLimit = -11.95f;
    public float rightLimit = -9.94f;

    private int direction = 1;

    Animator animator;

    public GameObject player;

    public GameObject ui;

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
            transform.position = new Vector2(rightLimit, transform.position.y);
            
            direction = -1;
            Flip();
        }
        else if (transform.position.x <= leftLimit)
        {
            transform.position = new Vector2(leftLimit, transform.position.y);
            
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        ProgressBar life = ui.GetComponent<UIDocument>().rootVisualElement.Q("Life") as ProgressBar;
        life.value -= 25;
        player.GetComponent<CharacterControllerTransform>().lifes -= 1;
    }
}
