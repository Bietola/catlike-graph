using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform transformPrefab = default;

    [SerializeField, Range(10, 100)]
    int resolution;

    private void plotFunc(Func<int, int> func) {
        // NB. Floor division forces even res. (kept for simplicity)
        var bounds = resolution / 2;

        for (int i = -bounds; i < bounds; i++) {
            plotPoint(i, func(i));
        }
    }

    private void plotPoint(int x, int y) {
        var point = Instantiate(transformPrefab);

        // Bind Point to Graph transform
        point.SetParent(transform);

        // Scale position and dimensions appropiately
        point.localPosition = (Vector3.right * x + Vector3.up * y) / resolution;
        point.localScale = Vector3.one / resolution;
    }

    void Awake()
    {
        plotFunc(x => x);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
