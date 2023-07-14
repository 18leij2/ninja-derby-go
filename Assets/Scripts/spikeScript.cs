using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class spikeScript : MonoBehaviour {
    public AudioSource sadDead;

    private void Start()
    {
        sadDead = GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            SceneManager.LoadScene(2);
            sadDead.Play();
        }
    }

        

}