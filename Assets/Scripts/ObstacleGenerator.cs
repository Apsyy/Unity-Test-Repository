using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstacle;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = MinSpeed;
        generateObstacle();
    }
    public void GenerateNextObstGap()
    {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("generateObstacle", randomWait);
    }
    void generateObstacle()
    {
        GameObject ObstacleIns = Instantiate(obstacle, transform.position, transform.rotation);

        ObstacleIns.GetComponent<MovementobstacleScript>().obstacleGenerator = this;
    }
    // Update is called once per frame
    void Update() //increase speed as time goes on
    {
        if (currentSpeed < MaxSpeed)
        {
            currentSpeed += SpeedMultiplier;
        }
    }
}