using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float angle = -1;
    void Start()
    {
        
    }

    void Update()
    {
        Transform car = this.gameObject.transform;
        car.transform.Rotate(0, angle, 0);
    }
}
