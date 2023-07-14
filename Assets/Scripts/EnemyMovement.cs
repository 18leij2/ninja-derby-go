using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = .02f;
    private Animator anim;
    private Rigidbody2D rb;
    private bool pursuing, dead;
    [SerializeField] private float distance, movementSpeed;
    [SerializeField] private GameObject playerReference;
    public AudioSource tickSource;
    public Transform Player;
    public float rotationSpeed;
    

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        tickSource = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dead)
        {
            if (Vector2.Distance(transform.position, playerReference.transform.position) <= distance)
            {
                pursuing = true;
                anim.SetBool("Pursuing", pursuing);
                Vector3 PlayerDir = Player.position - transform.position;
                float angle = Mathf.Atan2(PlayerDir.y, PlayerDir.x) * Mathf.Rad2Deg - 80f;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 75);
                transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);



            }
            else
            {
                pursuing = false;
                anim.SetBool("Pursuing", pursuing);
            }
        }

    }
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shuriken")
        {
            anim.SetBool("Dead", true);
            GetComponent<CircleCollider2D>().enabled = false;
            Destroy (collision.gameObject);
            tickSource.Play();
            yield return new WaitForSeconds(.1f);
            Destroy (gameObject);
        }
        else if (collision.CompareTag("Player")) 
        {
            SceneManager.LoadScene(2);
        }
    }   
}

