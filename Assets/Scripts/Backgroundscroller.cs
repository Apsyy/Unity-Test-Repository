using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundscroller : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private float width;
    public float speed;
    public float MinSpeed;
    public float MaxSpeed;
    

    public float SpeedMultiplier;
    // Start is called before the first frame update
    void Awake()
    {
        speed = MinSpeed; 
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = boxCollider.size.x;
        rb.velocity = new Vector2(speed, 0);
        //generateObstacle();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector = new Vector2(width * Time.deltaTime, 0);
        if (transform.position.x < -width)
        {

            transform.position = (Vector2)transform.position + vector;
            //transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (speed > MaxSpeed)
        {
            speed -= SpeedMultiplier;
        }
        

    }
  
}
