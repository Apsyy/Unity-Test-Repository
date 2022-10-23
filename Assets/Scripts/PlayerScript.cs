using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    public static event Action onPlayerDeath; // action event used for when player dies

    public float JumpForce;
    [SerializeField]
    bool isGrounded = false;
    
    Rigidbody2D RigidBody;
    private void Awake() //Gets Rigid body component from the player 
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame 
    void Update()
    {
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
    }
}
