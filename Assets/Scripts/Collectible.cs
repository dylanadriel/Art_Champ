using UnityEngine;
using UnityEngine.UIElements;


public class Collectible : MonoBehaviour


{
    public GameObject ui;
    
    void OnTriggerEnter2D ()
    {
        Label pointsLabel = ui.GetComponent<UIDocument>().rootVisualElement.Q<Label>("Points");
        int currentPoints = int.Parse(pointsLabel.text);
        currentPoints += 1;
        pointsLabel.text = currentPoints.ToString();
        
        GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

    }

    //void OnCollisionEnter2D()
    //{
        //ProgressBar life = ui.GetComponent<UIDocument>().rootVisualElement.Q("Life") as ProgressBar;
        //life.value -= 25;
        //player.GetComponent<CharacterControllerTransform>().lifes -= 1;
    //}
}
