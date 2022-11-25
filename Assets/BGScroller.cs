using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    //[Range(-1f, 1f)]
   
    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;
    public float SpeedMultiplier;

    private float offset;
    private Material mat;
    void Awake()
    {
        currentSpeed = MinSpeed;
        
    }
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed < MaxSpeed)
        {
            currentSpeed += SpeedMultiplier;
        }
        offset += (Time.deltaTime * currentSpeed)/79.5f;
        //offset += (Time.deltaTime * currentSpeed);

        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
