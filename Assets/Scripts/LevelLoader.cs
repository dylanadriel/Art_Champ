using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
