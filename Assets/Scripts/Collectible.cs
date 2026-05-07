using UnityEngine;

public class Collectible : MonoBehaviour
{
    void OnTriggerEnter2D ()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
