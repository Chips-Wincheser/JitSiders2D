using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonExitMenu : MonoBehaviour
{
    public void GoingMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
