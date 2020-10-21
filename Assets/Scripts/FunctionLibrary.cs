using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class FunctionLibrary : MonoBehaviour
{
    static public float SimpleWave(float x, float _z, float t) {
        float output = Sin(PI * (x + t));

        return output;
    }

    static public float Wave(float x, float _z, float t) {
        float output = Sin(PI * (x + t)) + 0.5f * Sin(2f * PI * (x + t));
        output /= 1.5f;

        return output;
    }
}
