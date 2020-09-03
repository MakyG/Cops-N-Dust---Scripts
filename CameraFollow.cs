using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");   
    }

    void LateUpdate()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            return;
        }
        Movement();
    }

    void Movement()
    {
        float posX = player.transform.position.x;
        float posY = player.transform.position.y;
        float posZ = player.transform.position.z;

        transform.position = new Vector3(posX, posY, posZ);
    }
}
