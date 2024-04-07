using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1Script : MonoBehaviour
{
    private readonly float rotationSpeed = 100f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
    }
}
