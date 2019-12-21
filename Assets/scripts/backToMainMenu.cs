using UnityEngine;
using UnityEngine.UI;


public class backToMainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject current;
    public void backToMenu() {
        mainMenu.SetActive(true);
        current.SetActive(false);
       

    }

}
