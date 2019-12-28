using UnityEngine;
using UnityEngine.UI;
public class axe : MonoBehaviour
{
    //fields
    private int successHits = 0;
    private int numberofAxes;
    public float range = 4f;

    //unity objects
    public Text axeCounter;
    public Text scoreText;
    public GameManager manager;
    public AudioClip hitting;
    public AudioSource forHit;
    public Camera cam;
    public GameObject pickaxe;
    public Material red;
    public Material black;
    public Material axe_default;

    //variables
    int N;
    int numberofAxesLeft;
    
    private void Start()
    {
        forHit.clip = hitting;
        numberofAxes = manager.getAxeNumber();
        numberofAxesLeft = numberofAxes;
        N = manager.getN();
    }

	//bring back the axe to create animation
	void rotateAxeBack()
    {  
        pickaxe.transform.Rotate(0, -45, 0);
    }
    void Update()
    {
        // display score per frame
        int time =(int) Time.time;          //seconds in game passed
        int score_number = N * N - time-(numberofAxes-numberofAxesLeft)*50;
        scoreText.text = "Score:"+score_number.ToString();
        manager.setCurrentScore(score_number);          //updating manager score value
        axeCounter.text = "Axes:" + numberofAxesLeft.ToString();

        if (Input.GetButtonDown("Fire1") && numberofAxesLeft>0) //left mb
        {   
            pickaxe.transform.Rotate(0,45,0);
            hit();
            Invoke("rotateAxeBack",0.1f);  //delaying to make axe animated
        }
        if (Input.GetKey("f")) //right mb
		{     
            Debug.Log("This pick up button");
            pickupAxe();
        }
        //changing hold axe material on successful hits
        if (successHits > 5 && successHits < 8)
        {
            pickaxe.GetComponent<MeshRenderer>().material = red;
        }
        else if (successHits >= 8)
        {
            pickaxe.GetComponent<MeshRenderer>().material = black;
        }
        else
        {
            pickaxe.GetComponent<MeshRenderer>().material = axe_default;
        }

        if (successHits == 10) //Every 10 hits successful the axe breaks
		{        
            numberofAxesLeft= numberofAxesLeft - 1;
            axeCounter.text = "Axes:" + numberofAxesLeft.ToString();
            successHits = 0;
        }
        if (numberofAxesLeft == 0)
        {
            pickaxe.SetActive(false);
        }
        else
        {
            pickaxe.SetActive(true);

        }
    }
    void hit()
    {
        RaycastHit obj;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out obj, range))
        {
           // Debug.Log(obj.transform.tag);
            Target target =obj.transform.GetComponent<Target>();
            if (target!=null && target.tag == "obstacle")
            {

                forHit.Play();
                target.takeDamage(1);                   //does 1 damage point to block
                successHits++;                          //does damage to axe
                
            }
        }
    }
    void pickupAxe() {
        RaycastHit obj;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out obj, range))
        {
            Debug.Log(obj.transform.tag);
            Pickup axe= obj.transform.GetComponent<Pickup>();
     

            if (axe != null && axe.tag == "axe")
            {
                Debug.Log("Picked up axe!");
                Destroy(axe.gameObject);              //destroy the object after claimed
                numberofAxesLeft++;
            }
        }
    }
}
