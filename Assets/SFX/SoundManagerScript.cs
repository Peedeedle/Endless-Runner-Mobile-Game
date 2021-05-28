using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public AudioSource Ambient;
    public AudioSource MinecartMoving;
    


    public void PlayAmbient()
    {
        Ambient.Play();
    }



    public void PlayMinecartMoving()
    {
        MinecartMoving.Play();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sound")
        {
            MinecartMoving.Play();
        }
            
    }
    

    

}
