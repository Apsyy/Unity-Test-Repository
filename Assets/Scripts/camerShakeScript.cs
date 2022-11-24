using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerShakeScript : MonoBehaviour
{
    public bool start = false;
    public AnimationCurve curve;
    public float duration = 1f;
    

    private void Update()
    {
        if(start)
        {
            start = false;
            StartCoroutine(Shaking(duration));
        }
    }

    IEnumerator Shaking(float _Duration)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while(elapsedTime < _Duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / _Duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }
}
