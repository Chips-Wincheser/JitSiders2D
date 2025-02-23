using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    [SerializeField] private int indexLevl;

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        if (currentSceneIndex + 2 < totalScenes)
        {
            SceneManager.LoadScene(currentSceneIndex + indexLevl);
        }
    }
}
