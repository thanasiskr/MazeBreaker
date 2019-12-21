using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    //fields
    private int numberofAxes;
    private int N;
    private int L;
    private int currentScore;
    private bool gameEnded = false;

    //unity objects
    public GameObject winUi;
    public GameObject loseUi;
    public Text finalScore;
    public AudioClip tada;
    public AudioSource source;

    public Camera mainCamera;
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public Camera camera4;
    public Camera camera5;

    int currentCamera = 0;

    Camera[] cameras = new Camera[6];
    private void Start()
    {
        source.clip = tada;
        cameras[0] = mainCamera;
        cameras[1] = camera1;
        cameras[2] = camera2;
        cameras[3] = camera3;
        cameras[4] = camera4;
        cameras[5] = camera5;
    }
   

    private void Update()
    {
        //camera buttons
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            cameras[0].gameObject.SetActive(true);
            cameras[1].gameObject.SetActive(false);
            cameras[2].gameObject.SetActive(false);
            cameras[3].gameObject.SetActive(false);
            cameras[4].gameObject.SetActive(false);
            cameras[5].gameObject.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cameras[0].gameObject.SetActive(false);
            cameras[1].gameObject.SetActive(true);
            cameras[2].gameObject.SetActive(false);
            cameras[3].gameObject.SetActive(false);
            cameras[4].gameObject.SetActive(false);
            cameras[5].gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cameras[0].gameObject.SetActive(false);
            cameras[1].gameObject.SetActive(false);
            cameras[2].gameObject.SetActive(true);
            cameras[3].gameObject.SetActive(false);
            cameras[4].gameObject.SetActive(false);
            cameras[5].gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cameras[0].gameObject.SetActive(false);
            cameras[1].gameObject.SetActive(false);
            cameras[2].gameObject.SetActive(false);
            cameras[3].gameObject.SetActive(true);
            cameras[4].gameObject.SetActive(false);
            cameras[5].gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            cameras[0].gameObject.SetActive(false);
            cameras[1].gameObject.SetActive(false);
            cameras[2].gameObject.SetActive(false);
            cameras[3].gameObject.SetActive(false);
            cameras[4].gameObject.SetActive(true);
            cameras[5].gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            cameras[0].gameObject.SetActive(false);
            cameras[1].gameObject.SetActive(false);
            cameras[2].gameObject.SetActive(false);
            cameras[3].gameObject.SetActive(false);
            cameras[4].gameObject.SetActive(false);
            cameras[5].gameObject.SetActive(true);
        }


    }
    
    
    //getters and setters for gameManager fields
    public int getCurrentScore() {
        return currentScore;
    }
    public void setCurrentScore(int score) {
        currentScore = score;
    }
    public void setN(int num) {
        N = num;
    }
    public int getN()
    {
       return (N);
    }

    public void setAxeNumber(int axes) {
        numberofAxes = axes;
        
    }
    public int getAxeNumber()
    {
        return (numberofAxes);

    }

    public void setLevelNumber(int num)
    {
        L = num;
       
    }
    public int getLevelNumber()
    {
       return L ;
    }

    public void endGame() {
        if (!gameEnded) {
            source.Play();
            finalScore.text = "Your score is:" + currentScore.ToString();
            winUi.SetActive(true);        //congrats screen
            Invoke("loadCredits", 3);       //wait 3 second ,then show credits scene
            gameEnded = true;
           
            
        }
        
    }
    private void loadCredits() {
        //cursor on
        Cursor.visible = true;
        SceneManager.LoadScene("credits", LoadSceneMode.Single);
    }
    public void gameOver() {
        if (!gameEnded)
        {
            loseUi.SetActive(true);
            Debug.Log("You gave up ,your score is 0");
            gameEnded = true;
            Application.Quit();  // quit the game works only if built!
            
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }


}
