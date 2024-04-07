using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2Script : MonoBehaviour
{
    private readonly float rotationSpeed = 100f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

    }
}
