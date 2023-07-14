using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
    public AudioSource collectSound;

	// Use this for initialization
	void Start () {
        collectSound = GetComponent<AudioSource>();
	}

    // Update is called once per frame
 


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                
              
                
                
                Destroy(gameObject);
            }
        }
    }
    

