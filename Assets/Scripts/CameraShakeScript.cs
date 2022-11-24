using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    public AnimationCurve curve;

    //public IEnumerator Shake (float _Duration, float _Magnitude)
    //{
    //    Vector3 originalPos = transform.localPosition;

    //    float elapsed = 0.0f;

    //    while (elapsed < _Duration)
    //    {
    //        float x = Random.Range(-1f, 1f) * _Magnitude;
    //        float y = Random.Range(-1f, 1f) * _Magnitude;

    //        transform.localPosition = new Vector3(x, y, originalPos.z);

    //        elapsed += 0.016f;

    //        yield return null;
    //    }

    //    transform.localPosition = originalPos;
    //}

    public IEnumerator Shake(float _Duration, float _Magnitude)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        Debug.Log("SHAKING!!!");

        while (elapsedTime < _Duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / _Duration) * _Magnitude;
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }
}
