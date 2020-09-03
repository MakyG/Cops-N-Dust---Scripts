using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilBehavior : MonoBehaviour
{
    [SerializeField]
    private int life = 2;
    [SerializeField]
    private GameObject explosionEffect;


    private int currentLife;
    private bool isColliding = false;
    private Rigidbody myBody;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        myBody = GetComponent<Rigidbody>();
        isColliding = false;
        currentLife = life;
    }


    void Update()
    {
        if (isColliding == true)
        {
            reduceLife();
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.collider.CompareTag("Civil"))
        {
            isColliding = true;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        
        if (other.collider.CompareTag("Player"))
        {
            isColliding = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        
        if (other.collider.CompareTag("Player"))
        {
            isColliding = false;
        }
    }

    public void reduceLife()
    {
        currentLife--;

        if (currentLife <= 0)
        {
            Debug.Log("Taxi destroyed");
            GameObject explosion = ObjectPooling.instance.GetPooledObject("Explosion");
            explosion.SetActive(true);
            explosion.transform.position = this.transform.position;
            gameObject.SetActive(false);
        }
    }
}
