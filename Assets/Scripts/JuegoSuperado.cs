using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class JuegoSuperado : MonoBehaviour
{
    // Variables para las referencias del UXML
    Button botonReempezar;
    Button botonMenuPrincipal;
    Button botonSalir;

    [SerializeField] private string sceneName;


    void OnEnable()
    {
        //pongo variable root para no tener que llamar a get component cada vez
        var root = GetComponent<UIDocument>().rootVisualElement;

        botonReempezar = root.Q<Button>("Reempezar"); 
        botonMenuPrincipal = root.Q<Button>("MenuPrincipal");
        botonSalir = root.Q<Button>("Salir");
        
        botonReempezar.clicked += StartGame;
        botonMenuPrincipal.clicked += ChangePage;
        botonSalir.clicked += SalirDelJuego;

    }

    void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    void ChangePage()
    {
        SceneManager.LoadScene("InitialScene");
    }


    void SalirDelJuego()
    {
        Application.Quit();

        //este if lo añado para que funcione también desde el editor y no solo con el juego compilado
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void OnDisable()
    {
        botonReempezar.clicked -= StartGame;
        botonMenuPrincipal.clicked -= ChangePage;
        botonSalir.clicked -= SalirDelJuego;
        //añado esto para que no se ejecuten varias veces las funciones
    }

}
