using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateWithTime : MonoBehaviour
{
    [SerializeField]
    private float deactivateTime;
    private float currentTime;
    void Start()
    {
        currentTime = deactivateTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            currentTime = deactivateTime;
            gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
