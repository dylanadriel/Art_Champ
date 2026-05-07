using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject imageToShow;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            imageToShow.SetActive(true);
        }
    }
}