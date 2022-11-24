using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    public static event Action onPlayerDeath; // action event used for when player dies
    AudioSource jumpSound;

    public float JumpForce;
    [SerializeField]
    bool isGrounded = false;
    bool hasWahooed = false;

    //for distance tracker
    public float rateOfDistance;
    public float distance;

    public CameraShakeScript cameraShake;
    [SerializeField] private float landingShakeDuration;
    [SerializeField] private float landingShakeMagnitude;
    [SerializeField] private float jumpingShakeDuration;
    [SerializeField] private float jumpingShakeMagnitude;

    Rigidbody2D RigidBody;
    
    private void Awake() //Gets Rigid body component from the player 
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Time.timeScale = 1;
        distance = 0;
        jumpSound = GetComponent<AudioSource>();
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
                StartCoroutine(cameraShake.Shake(jumpingShakeDuration, jumpingShakeMagnitude));
                if (!hasWahooed)
                {
                    jumpSound.Play();
                    hasWahooed = true;
                }

                RigidBody.AddForce(Vector2.up * JumpForce);
                isGrounded = false;

            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            StartCoroutine(cameraShake.Shake(landingShakeDuration, landingShakeMagnitude));
            if (isGrounded == false)
            {
                isGrounded = true;
                hasWahooed = false;
                
            }
        }

        // kill player when they collide with obstacle
        if (collision.gameObject.CompareTag("obstacle"))
        {
            //StartCoroutine(cameraShake.Shake(0.2f, 0.2f)); // camera shake no work bacause of pause game
            Time.timeScale = 0; // pauses game
            Debug.Log("DEAD");
            onPlayerDeath?.Invoke(); // invoking event when player dies
        }
    }
    
}
