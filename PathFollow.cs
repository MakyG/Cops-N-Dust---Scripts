using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathFollow : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 0;
    float distanceTravelled;

    private void Start()
    {
        distanceTravelled = Random.Range(-2700, 0);
    }

    void Update()
    {
        
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }
}
