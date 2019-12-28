using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teleporter_script : MonoBehaviour
{
    //Unity Objects
    public GameManager manager;
    public AudioClip teleportSound;
    public AudioSource tpSource;
    GameObject player;

    //global variables
    int spawn_index;
    int max;
    ArrayList teleporters;
    
    void Start()
    {
        tpSource.clip = teleportSound;
        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();  //getComponent if its attached to smth,first i need to find it with findObjectofType()
        player = manager.getPlayer();
        
       
        teleporters = manager.getTeleporterList();
        max = teleporters.Count; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.collider.tag == "player"))       //player collides with teleporter floor
        {
            if (!manager.getTeleported())
            {
                tpSource.Play();
                Debug.Log("Where to cap'?");


                // lets tp random for now
                System.Random rand = new System.Random();
                int j = rand.Next(0, max);
                int i;


                //finding upper level teleporter
                float x = player.transform.position.x;                               //getting current player position
                float y = player.transform.position.y;
                float z = player.transform.position.z;
                
                for (i = 0;i< max; i++)
                {
                    float pos = y;
                    if (((Vector3)teleporters[i]).y > y+3 )                 
                    {
                        Debug.Log("Found upper level!");
                        spawn_index = i;
                        break;
                    }
                    else
                    {
                        Debug.Log("Didnt find any .Go random");
                        spawn_index = j;
                    }
                }

                //transfer player
                
                player.SetActive(false);
               
                Vector3 spawn_position = (Vector3)teleporters[spawn_index];
                player.transform.SetPositionAndRotation(spawn_position, Quaternion.identity);
                manager.teleportFlash();
                player.SetActive(true);
                manager.setTeleported(true);
            }
            else
            {
                manager.setTeleported(false);
            }
        }
    }
}

