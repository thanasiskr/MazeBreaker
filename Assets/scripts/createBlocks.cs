using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;


public class createBlocks : MonoBehaviour
{
    //unity objects
    public GameManager manager;
    

    public Transform player;
    public GameObject player_obj;

    public AudioClip backgroundMusic;
    public AudioSource source;

    public Text axeCounter;
    public Text scoreText;

    public GameObject brickBlock;
    public GameObject rockBlock;
    public GameObject marbleBlock;
    public GameObject redBlock;
    public GameObject greenBlock;
    public GameObject blueBlock;

    //variables
     int N = 20;
     int L = 20;
     int K = 0;
     int score = 0;

     Vector3[] emptySpots =new Vector3[5];       //number of empty position vectors for the player location
     int emptyCounter=0;                         //current items in emptySpots 
     bool player_active = false;                 //by default player item is disabled until put in position

    
    void setPlayerPosition(Vector3[]array) {
        if (player_active == false)
        {
            System.Random rnd = new System.Random();
            int i = rnd.Next(0,emptyCounter);
            player.SetPositionAndRotation(array[i], Quaternion.identity);
            player_obj.SetActive(true);
            player_active = true;
        }

    }
    void Start()
    {
        int i = 0;
        int j = 0;
        int k = 0;
        int x = 0;
        int y = 0;
        int z = 0;

        String[] split=null;
        char[] splitchar = { '=' };

        source.clip = backgroundMusic;
        source.Play();

        StreamReader reader = new StreamReader("Assets/scripts/ex.maz");

        //game starts hide the cursor!
        Cursor.visible= false;
        //fullscreen
        //Screen.SetResolution(640, 480, true,60);


        //getting Number of L converting it to int and assigning

         string data = reader.ReadLine();
         split = data.Split(splitchar);
         L = Int32.Parse(split[1]);
         Debug.Log("This must be 4:"+L);


         //getting Number of N
         data = reader.ReadLine();
         split = data.Split(splitchar);
         N=Int32.Parse(split[1]);
         Debug.Log("This must be 16:" +N);

        //getting Number of K
        data = reader.ReadLine();
        split = data.Split(splitchar);
        K= Int32.Parse(split[1]);
        Debug.Log("This must be 5:" + K);

        //Display default number of axes
        axeCounter.text= "Axes:" + K.ToString();

        //Display score is 0

        scoreText.text ="Score:" +score.ToString();
        

        string[] types=new string[16];
        for (i = 0; i < L; i++) //level for loop
        {
            //parsing "Level x"
            data = reader.ReadLine();
            Debug.Log("Skipped: "+data);
            
            for (j = 0; j < N; j++)
            {
                if (data != null && !data.Equals("END OF MAZE"))
                {
                    data = reader.ReadLine();
                    //Debug.Log("Read line:"+data);         //reading each line ,splitting and converting each char to string.
                    types = data.Split(' ');            //cube types for each line
                   // Debug.Log("Size of array:"+types.Length);
                    
                    
                }
                
                for (k = 0; k < N; k++)
                {
                    
                    //Vector3 pos = new Vector3(-47 + z, 3 + y, -47 + x );    //to look the .maz from the front
                    Vector3 pos = new Vector3(-47 + x, 3 + y, -47 + z); //default positions

                    if (types[k].Equals("R")) {
                        Instantiate(redBlock, pos, Quaternion.identity);
                    }
                    if (types[k].Equals("G")) {
                        Instantiate(greenBlock, pos, Quaternion.identity);
                    }
                    if (types[k].Equals("B")) {
                        Instantiate(blueBlock, pos, Quaternion.identity);
                    }
                    if (types[k].Equals("T2")) {
                        Instantiate(marbleBlock, pos, Quaternion.identity);
                    }
                    if (types[k].Equals("T3")) {
                        Instantiate(rockBlock, pos, Quaternion.identity);

                    }
                    if (types[k].Equals("T1")) {
                        Instantiate(brickBlock, pos, Quaternion.identity);

                    }
                    if (types[k].Equals("E"))
                    {
                        if (i == 0 && emptyCounter<5) {                             //change 5-->add more vectors
                            //storing 5 empty spots for random player start position
                            Vector3 emptypos = new Vector3(-47 + x, 3 + y, -47 + z);
                            emptySpots[emptyCounter] = emptypos;
                            emptyCounter++;
                        }
                        
                    }
                    x = x + 5;
                    
                }
                x = 0;
                z = z + 5;
               
            }

            y = y + 5;
            z = 0;
            x = 0;

        }
        setPlayerPosition(emptySpots);
        //The gameManager will hold important game information
        manager.setN(N);
        manager.setLevelNumber(L);
        manager.setAxeNumber(K);
       
    }
   



}
