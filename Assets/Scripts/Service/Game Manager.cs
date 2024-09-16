using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject inventoryCanvas;
    [SerializeField] GameObject countdownCanvas;

    public static bool DoomsdayHasStarted = false;

    public void WinScenario()
    {
        winCanvas.SetActive(true);
        inventoryCanvas.SetActive(false);
        countdownCanvas.SetActive(false); 

        Application.Quit();
    }

    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
