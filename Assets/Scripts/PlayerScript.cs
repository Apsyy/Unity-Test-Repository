using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
    [SerializeField]
    bool isGrounded = false;

    Rigidbody2D RigidBody;
    private void Awake() //Gets Rigid body component from the player 
    {
        RigidBody = GetComponent<Rigidbody2D>();
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
    }
}
