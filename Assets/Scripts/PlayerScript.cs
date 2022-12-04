using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public static event Action onPlayerDeath; // action event used for when player dies
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource landSound;

    public float JumpForce;
    [SerializeField]
    bool isGrounded = false;
    bool hasWahooed = false;
    private bool isAlive;

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
        isAlive = true;
        
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
                    //landSound.Play();
                    jumpSound.Play();
                    hasWahooed = true;
                }

                RigidBody.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }
        
        if (!isAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // restart level when player dies and presses space
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if(Input.GetKeyDown(KeyCode.Escape))
            {
                // return to main menu when player dies and presses ESC
                SceneManager.LoadScene(0);
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
                landSound.Play();
                
            }
        }

        // kill player when they collide with obstacle
        if (collision.gameObject.CompareTag("obstacle"))
        {
            //StartCoroutine(cameraShake.Shake(0.2f, 0.2f)); // camera shake no work bacause of pause game
            Time.timeScale = 0; // pauses game
            isAlive = false;
            Debug.Log("DEAD");
            onPlayerDeath?.Invoke(); // invoking event when player dies
        }
    }
    
}
