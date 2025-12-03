using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    [SerializeField] private float amplitude = 0.25f; // How far it moves up/down
    [SerializeField] private float frequency = 1f;    // Speed of bobbing

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // World position
    }

    void Update()
    {
        // Smooth sine wave offset
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;

        // Apply offset to starting position
        transform.position = startPos + new Vector3(0, yOffset, 0);
    }
}

