using UnityEngine;
using UnityEngine.UIElements;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject imageToShow;
    [SerializeField] private GameObject ui;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Label pointsLabel = ui.GetComponent<UIDocument>().rootVisualElement.Q<Label>("Points");

            int points = int.Parse(pointsLabel.text);

            if (points == 5)
            {
                imageToShow.SetActive(true);
                ui.SetActive(false);
            }
        }
    }
}