using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter_script : MonoBehaviour
{
    public GameManager manager;
    GameObject player;


    int spawn_index;
    int max;
    ArrayList teleporters;
    bool teleported = false;
    public AudioClip teleportSound;
    public AudioSource tpSource;

    Vector3 playerpos;
    void Start()
    {
       
        tpSource.clip = teleportSound;
        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();  //getComponent if its attached to smth,furst i need to find it with findObjectofType()
        player = manager.getPlayer();
        
        float x    = player.transform.position.x;                               //getting current player position
        float y = player.transform.position.y;
        float z = player.transform.position.z;
        playerpos = new Vector3(x,y,z);
        teleporters = manager.getTeleporterList();
        max = teleporters.Count;
      

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if ((collision.collider.tag == "player") && (teleported == false))       //player collids with teleporter floor
        {
            
            tpSource.Play();
            Debug.Log("Where to cap'?");
           
            // lets tp random for now
            System.Random rand = new System.Random();

            int j=rand.Next(0,max);
            int i;
            spawn_index = j;
           
            //makaroni
            /*for (i = 0;i< max; i++) {
                float pos = playerpos.y;
                if (((Vector3)teleporters[i]).y+8==pos+3) {
                    spawn_index = i;
                    break;
                
                }
            }*/
            player.SetActive(false);
            Vector3 spawn_position = (Vector3)teleporters[spawn_index];
            player.transform.SetPositionAndRotation(spawn_position, Quaternion.identity);
            player.SetActive(true);
            teleported = true;

        }
        else
        {
            teleported = false;

        }


    }

}

