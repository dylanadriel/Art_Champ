using UnityEngine;
using UnityEngine.UIElements;

public class ScriptCreditos : MonoBehaviour
{
    [SerializeField]
    GameObject menuPage;

    void OnEnable()
    {

        Button BackButton = GetComponent<UIDocument>().rootVisualElement.Q("BackButton") as Button;
        BackButton.clicked += ChangePage;

    }

        void ChangePage()
    {
        gameObject.SetActive(false);
        menuPage.SetActive(true);
    }


}
