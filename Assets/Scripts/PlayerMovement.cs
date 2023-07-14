using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D player;
    [SerializeField] private float forceMove = 10f;
    [SerializeField] private float forceJump = 10f;
    [SerializeField] private GameObject shuriken;
    private bool onGround;
    private bool onWall;
    private bool isSliding;
    private Animator anim;
    private Transform wall;
    public static bool isEnd;
    [SerializeField] private AudioClip[] clips;
    private AudioSource[] sfx;
    /*
     0 - JumpSound
     */
	
    // Use this for initialization
	void Awake () {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sfx = GetComponents<AudioSource>();
        
	}

    // Update is called once per frame
    void Update()
    {
        if (!isEnd)
        {
            if (!isSliding)
            {
                float horizontalInput = Input.GetAxisRaw("Horizontal");

                anim.SetFloat("HorizontalForce", Mathf.Abs(horizontalInput));
                Vector2 currentVelocity;

                if (Input.GetKeyDown(KeyCode.Space) && onGround)
                {
                    sfx[0].Play(); //Jumpsound
                    player.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
                }
                else if (Input.GetKeyDown(KeyCode.F)) {
                    GameObject throwObject;
                    sfx[3].Play();

                    if (transform.localScale.x == 1)
                        throwObject = Instantiate(shuriken, new Vector2(transform.position.x + 1, transform.position.y + 1), Quaternion.identity);
                    else

                        throwObject = Instantiate(shuriken, new Vector2(transform.position.x - 1, transform.position.y + 1), Quaternion.identity);

                    throwObject.transform.localScale = new Vector2(transform.localScale.x, 1);
                }



                currentVelocity = new Vector2(horizontalInput * forceMove, player.velocity.y);


                if (horizontalInput != 0)
                    transform.localScale = new Vector2(horizontalInput, 1);

                else if (!onGround)
                    currentVelocity.x = player.velocity.x * 1f;
                player.velocity = currentVelocity;
            }

            anim.SetFloat("VerticalForce", player.velocity.y);

            if (!onWall || onGround)
                isSliding = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "End")
        {
            isEnd = true;
            sfx[4].Play();
        }
        if (collision.gameObject.tag == "Collectable")
        {
            sfx[5].Play();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            onGround = true;
      


        else if (collision.gameObject.tag == "Wall")
        {
            onWall = true;
            isSliding = true;
            wall = collision.transform;
        }
        anim.SetBool("OnGround", onGround);
        anim.SetBool("OnWall", onWall);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            onGround = false;
        else if (collision.gameObject.tag == "Wall")
            onWall = false;
        anim.SetBool("OnGround", onGround);
        anim.SetBool("OnWall", onWall);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            onGround = true;
        else if (collision.gameObject.tag == "Wall")
            onWall = true;
        anim.SetBool("OnGround", onGround);
        anim.SetBool("OnWall", onWall);
    }

    

    private void ChangeDirection()
    {
        if (wall != null)
        {
            if (wall.position.x <= transform.position.x)
                transform.localScale = new Vector2(1, 1);
            else
                transform.localScale = new Vector2(-1, 1);
        }
    }
    private void Step()
    {
        if (onGround)
            sfx[1].Play();
    
    }

    private void Step2()
    {
        if (onGround)
            sfx[2].Play();
    }
   
    


}
