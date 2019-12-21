using UnityEngine;
using System;

public class Target : MonoBehaviour
{

    public GameObject debris;
    public GameObject pickup_axe;
    public AudioClip crumble;
    public AudioSource forCrumble;

     
    public int health = 3;
    public float x;
    public float y;
    public float z;

    private GameObject[] spawnedDebris = new GameObject[8];         //store all debris objects here
    private void Start()
    {
       
        forCrumble.clip = crumble;

    }
    public void takeDamage(int amount) {
        health -= amount;
        if (health == 0) {                                  //cube breaks
            forCrumble.Play();
             x = transform.position.x;
             y = transform.position.y-2;                 //at the height of the player
             z = transform.position.z;

            transform.position = Vector3.one * 9999f;   //move object out of screen i ll  destroy it later
            spawn_axes();
            Invoke("break_obstacle",1f);                //delay destruction ,for audio to finish
            
            //spawn debris
            Vector3 vector = new Vector3(x,y,z);
            spawnDebris(vector);
            Invoke("despawnDebris",1);
        }
    }
    void break_obstacle() {
        Destroy(gameObject);
       
    }
    void spawn_axes() {
        //if a cube breaks i can randomly spawn an axe that can be picked up
        System.Random rnd = new System.Random();
        int i = rnd.Next(0, 4);      //rand num from(0,3)
        if (i == 0 || i == 1)
        {                                                //50% chance of spawing         
            Vector3 pos = new Vector3(x,y,z);       //spawing axe at distance 1 from the terrain at the position of the broken cube
            Instantiate(pickup_axe, pos, Quaternion.identity);
            
        }
      


    }
    void despawnDebris() {
        int i;
        for (i = 0; i < 8; i++)
        {

            Destroy(spawnedDebris[i]);
        }
        
    }
    

    void spawnDebris(Vector3 vector)
    {
        //Vector3 pos = new Vector3(x, y, z);
        int i;
        for (i = 0; i < 8; i++) {
            //vector.x = vector.x + i * 0.5f;
            vector.z = vector.z + i*0.1f;
            vector.y = vector.y + i * 0.1f;

            spawnedDebris[i]=Instantiate(debris, vector, Quaternion.identity);
        }


    }


}
