using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    public static int policeCarsDestroyed = 0;
    [SerializeField]
    private float invincibleTime = 1f;
    [SerializeField]
    private int life = 4;
    [SerializeField]
    private GameObject smokeEffect, fireEffect, explosionEffect;
    

    private float currentInvincibleTime;
    private int currentLife;
    private bool isColliding = false;
    private Rigidbody myBody;
    public GameObject redLight, blueLight;

    void ChangeLight()
    {
        redLight.SetActive(true);
        blueLight.SetActive(false);
    }
    void ChangeLight2()
    {
        redLight.SetActive(false);
        blueLight.SetActive(true);
    }


    IEnumerator Change()
    {
        ChangeLight();
        yield return new WaitForSeconds(0.275f);
        ChangeLight2();
        yield return new WaitForSeconds(0.275f);
        StartCoroutine(Change());
    }


    
    void Update()
    {
        if (isColliding == true)
        {
            currentInvincibleTime -= Time.deltaTime;
            if (currentInvincibleTime <= 0)
            {
                isColliding = false;
                reduceLife();
            }
        }
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            isColliding = true;
        }
        if (other.collider.CompareTag("Tree"))
        {
            reduceLife();
        }
        if (other.collider.CompareTag("Civil"))
        {
            reduceLife();
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.collider.CompareTag("Building"))
        {
            reduceLife();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            isColliding = false;
        }
        if (other.collider.CompareTag("Tree"))
        {
            isColliding = false;
        }
    }

    public void reduceLife()
    {
        currentLife--;
        currentInvincibleTime = invincibleTime;

        if (currentLife == 4 || currentLife == 3 || currentLife == 2)
        {
            smokeEffect.SetActive(true);
        }
        if (currentLife == 1)
        {
            smokeEffect.SetActive(false);
            fireEffect.SetActive(true);
        }

        if (currentLife <= 0)
        {
            policeCarsDestroyed++;
            Debug.Log("Enemy destroyed");
            GameObject explosion = ObjectPooling.instance.GetPooledObject("Explosion");
            explosion.SetActive(true);
            explosion.transform.position = this.transform.position;
            EnemySpawner.instance.CurrentPoliceCar--;
            gameObject.SetActive(false);

        }
    }
    public void DefaultSetting()
    {
        StartCoroutine(Change());
        policeCarsDestroyed = 0;
        myBody = GetComponent<Rigidbody>();
        isColliding = false;
        currentLife = life;
        smokeEffect.SetActive(false);
        fireEffect.SetActive(false);
    }
}
