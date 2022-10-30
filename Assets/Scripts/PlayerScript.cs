using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    public static event Action onPlayerDeath; // action event used for when player dies

    public float JumpForce;
    [SerializeField]
    bool isGrounded = false;

    //for distance tracker
    public float rateOfDistance;
    public float distance;
    
    public int score;

    Rigidbody2D RigidBody;
    private void Awake() //Gets Rigid body component from the player 
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Time.timeScale = 1;
        distance = 0;
        score = 0;
    }

    // Update is called once per frame 
    void Update()
    {

        // update distance
        distance += Time.deltaTime * rateOfDistance;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                RigidBody.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }

        // kill player when they collide with obstacle
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Time.timeScale = 0; // pauses game
            Debug.Log("DEAD");
            onPlayerDeath?.Invoke(); // invoking event when player dies
        }

        // player collides with score object, increase score by 1
        if (collision.gameObject.CompareTag("score"))
        {
            score++;
        }
    }
    
}
