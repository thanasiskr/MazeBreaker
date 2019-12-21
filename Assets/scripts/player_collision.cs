﻿using UnityEngine;

public class player_collision : MonoBehaviour
{
    //unity objects
    public AudioClip bump;
    public AudioSource source;
    void Start()
    {
        source.clip = bump;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "obstacle")       //getting colliding object tag
        {    
            source.Play();
        }
    }

}
