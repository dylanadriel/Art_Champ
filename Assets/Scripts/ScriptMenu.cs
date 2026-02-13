using UnityEngine;
using UnityEngine.UIElements;

public class ScriptMenu : MonoBehaviour
{
    [SerializeField]
    GameObject creditsPage;

    [SerializeField]
    Texture2D backgroundImage;

    // Variables para las referencias del UXML
    Button botonReanudar;
    Button botonPlay;
    Button botonAjustes;
    Button botonCredits;
    Button botonAccesibilidad;
    Button botonSalir;

    // Variables de control
    VisualElement OpcionesAccesibilidad;
    bool accesibilidadActiva = false;
    float tamanoFuente = 20f;


    void Awake()
    {
        //pongo variable root para no tener que llamar a get component cada vez
        var root = GetComponent<UIDocument>().rootVisualElement;

        botonReanudar = root.Q<Button>("Reanudar"); 
        botonPlay = root.Q<Button>("PlayButton");
        botonAjustes = root.Q<Button>("Ajustes");
        botonCredits = root.Q<Button>("CreditsButton");
        botonAccesibilidad = root.Q<Button>("Accesibilidad");
        botonSalir = root.Q<Button>("Salir");
        
        Button PlayButton = root.Q("PlayButton") as Button;
        PlayButton.clicked += StartGame;

        Button CreditsButton = root.Q("CreditsButton") as Button;
        CreditsButton.clicked += ChangePage;

        Button Accesibilidad = root.Q("Accesibilidad") as Button;
        Accesibilidad.clicked += MenuAccesibilidad;

        Button Salir = root.Q("Salir") as Button;
        Salir.clicked += SalirDelJuego;

        //busco el togle por tipo porque por nombre me daba error todo el rato
        Toggle toggle = root.Q<Toggle>();
        toggle.RegisterValueChangedCallback(ChangeContrast);

        OpcionesAccesibilidad = root.Q("OpcionesAccesibilidad");
        OpcionesAccesibilidad.style.display = DisplayStyle.None;

        Button Mas = root.Q("Mas") as Button;
        Mas.clicked += AumentarFuente;

        Button Menos = root.Q("Menos") as Button;
        Menos.clicked += DisminuirFuente;

    }

    void StartGame()
    {
        gameObject.SetActive(false);
    }

    void ChangePage()
    {
        gameObject.SetActive(false);
        creditsPage.SetActive(true);
    }

    
    void ChangeContrast(ChangeEvent<bool> evt)
    {
    
    if (evt.newValue)
        {
            VisualElement background = GetComponent<UIDocument>().rootVisualElement.Q("background");
            background.style.backgroundImage = null;
            background.style.backgroundColor = Color.black;
        }

    else
        {
            VisualElement background = GetComponent<UIDocument>().rootVisualElement.Q("background");
            background.style.backgroundImage = new StyleBackground(backgroundImage);
        }
    }

    void MenuAccesibilidad()
    {
        accesibilidadActiva = !accesibilidadActiva;

        if (accesibilidadActiva)
            {
            OpcionesAccesibilidad.style.display = DisplayStyle.Flex;
            }
        else
            {
            OpcionesAccesibilidad.style.display = DisplayStyle.None;
            }   
    }
    void SalirDelJuego()
    {
        Application.Quit();

        //este if lo añado para que funcione también desde el editor y no solo con el juego compilado
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void AumentarFuente()
    {
        tamanoFuente += 2f;
        botonReanudar.style.fontSize = tamanoFuente;
        botonPlay.style.fontSize = tamanoFuente;
        botonAjustes.style.fontSize = tamanoFuente;
        botonCredits.style.fontSize = tamanoFuente;
        botonAccesibilidad.style.fontSize = tamanoFuente;
        botonSalir.style.fontSize = tamanoFuente;
    }

    void DisminuirFuente()
    {
        tamanoFuente -= 2f;
        botonReanudar.style.fontSize = tamanoFuente;
        botonPlay.style.fontSize = tamanoFuente;
        botonAjustes.style.fontSize = tamanoFuente;
        botonCredits.style.fontSize = tamanoFuente;
        botonAccesibilidad.style.fontSize = tamanoFuente;
        botonSalir.style.fontSize = tamanoFuente;
    }

}