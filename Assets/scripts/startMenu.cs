using UnityEngine;
using UnityEngine.SceneManagement;
public class startMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject controlPanel;
    public GameObject infoPanel;
    public void startGame() {
        SceneManager.LoadScene("gameScene", LoadSceneMode.Single);
    }

    public void showControls() {
        controlPanel.SetActive(true);
        mainMenu.SetActive(false);
        infoPanel.SetActive(false);
    }
    public void showInfo()
    {
        infoPanel.SetActive(true);
        controlPanel.SetActive(false);
        mainMenu.SetActive(false);

    }
    public void quitGame() {
        Application.Quit();
    }


}
