using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScript : MonoBehaviour {
    private Rigidbody2D rb;
    [SerializeField]private float movementSpeed;
    public float timer;
  

    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
     
    
	}

    // Update is called once per frame
    void Update() {
        rb.velocity = new Vector2(movementSpeed * transform.localScale.x, 0f);
        timer += 1.0f * Time.deltaTime;

        if (timer >= 3)
        {
            GameObject.Destroy(gameObject);
        }
     

    }

}
