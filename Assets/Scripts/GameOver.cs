using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Variables para las referencias del UXML
    Button botonReintentar;
    Button botonMenuPrincipal;
    Button botonSalir;

    void OnEnable()
    {
        //pongo variable root para no tener que llamar a get component cada vez
        var root = GetComponent<UIDocument>().rootVisualElement;

        botonReintentar = root.Q<Button>("Reintentar"); 
        botonMenuPrincipal = root.Q<Button>("MenuPrincipal");
        botonSalir = root.Q<Button>("Salir");
        
        botonReintentar.clicked += StartGame;
        botonMenuPrincipal.clicked += ChangePage;
        botonSalir.clicked += SalirDelJuego;

    }

    void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    void ChangePage()
    {
        SceneManager.LoadScene("SampleScene");
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
        botonReintentar.clicked -= StartGame;
        botonMenuPrincipal.clicked -= ChangePage;
        botonSalir.clicked -= SalirDelJuego;
        //añado esto para que no se ejecuten varias veces las funciones
    }

}
