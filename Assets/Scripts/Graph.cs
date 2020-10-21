using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab = default;

    [SerializeField, Range(10, 100)]
    int resolution = 25;

    [SerializeField, Range(0, 1)]
    int functionId = 0;

    List<Transform> points = new List<Transform>();

    private void plotFunc(Func<float, float, float, float> func, float t) {
        // NB. Floor division forces even res. (kept for simplicity)
        var bounds = resolution / 2;

        for (int i = 0; i < resolution; i++) {
            // To make the domain from [0, 1] to [-0.5, 0.5]
            int shifted_i = i - resolution / 2;

            // Scale coordinated to fit into domain
            float x = (float)shifted_i / resolution;
            float y = func(x, 0, t);

            // Modify position of cached point
            points[i].localPosition = Vector3.right * x + Vector3.up * y;
        }
    }

    void Awake()
    {
        // Allocate all needed point prefabs in memory
        for (int i = 0; i < resolution; i++) {
            var point = Instantiate(pointPrefab);
            point.SetParent(transform);

            point.localScale = Vector3.one / resolution;

            points.Add(point);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // TODO find out how type aliaes work
        Func<float, float, float, float> funToPlot = FunctionLibrary.SimpleWave;

        if (functionId == 0) {
            funToPlot = FunctionLibrary.SimpleWave;
        } else if (functionId == 1) {
            funToPlot = FunctionLibrary.Wave;
        } else {
            Debug.Assert(false, "Impossible function ID");
        }

        plotFunc(funToPlot, Time.fixedTime);
    }
}
