using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed;
    private float oldSpeed;
    private float acceleration = 0.7f;
    private float deceleration = 0.095f;
    private float turnIndex = 2.1f;
    [SerializeField]
    private float angleSpeed;
    private float oldAngleSpeed;
    [SerializeField]
    private int life = 5;
    [SerializeField]
    private GameObject smokeEffect, fireEffect, nitroEffect;
    private Rigidbody myBody;
    private int currentAngle;
    private int currentLife;
    private float nitro = 8f;
    private float nitroCoeficient = 1.5f;
    public static bool nitroOn = false;
    public float distanceTravelled = 0;
    Vector3 lastPosition;
    private void Update()
    {
        distanceTravelled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;

        if (Input.GetMouseButton(0))
        {
            float x = Input.mousePosition.x;

            if(x < Screen.width / 2.3 && x > 0)
            {

                MoveLeft();

            }

            if (x > Screen.width / 1.7 && x < Screen.width)
            {
                MoveRight();
            }
        }
        else
        {
            if ((speed / 4) < oldSpeed)
            {
                speed += acceleration;
                angleSpeed = oldAngleSpeed;
            }
        }
        if (nitroOn == true)
        {
            nitro -= 0.08f;
            nitroEffect.SetActive(true);
            if (speed < 50f)
            {
                speed += nitroCoeficient;
            }
        }
        if (nitro <= 0)
        {
            nitroOn = false;
        }
        if (nitroOn == false)
        {
            nitroEffect.SetActive(false);
            if (nitro < 8)
            {
                nitro += 0.013f;
            }
            if (speed > oldSpeed)
            {
                speed -= deceleration;
            }
        }
    }

    void Start()
    {
        nitroOn = false;
        lastPosition = transform.position;
        oldAngleSpeed = angleSpeed;
        oldSpeed = speed;
        myBody = GetComponent<Rigidbody>();
        currentLife = life;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void MoveLeft()
    {
        transform.Rotate(-Vector3.up * angleSpeed * Time.deltaTime);
        if (speed > (oldSpeed * 2))
        {
            speed -= deceleration;
            
        }
        if ((angleSpeed / 1.5) < oldAngleSpeed)
        {
            angleSpeed += turnIndex;
        }
    }

    public void MoveRight()
    {
        transform.Rotate(Vector3.up * angleSpeed * Time.deltaTime);
        if (speed > (oldSpeed * 2))
        {
            speed -= deceleration;
            
        }
        if ((angleSpeed / 1.5) < oldAngleSpeed)
        {
            angleSpeed += turnIndex;
        }
    }
    void ReduceLife()
    {
        currentLife -= 1;
        speed -= 0.25f;
        oldSpeed -= 0.25f;
        if (currentLife <= 4)
        {
            smokeEffect.SetActive(true);
        }
        if (currentLife <= 2)
        {
            smokeEffect.SetActive(false);
            fireEffect.SetActive(true);
        }
        if (currentLife <= 0)
        {
            GameObject explosion = ObjectPooling.instance.GetPooledObject("Explosion");
            explosion.SetActive(true);
            fireEffect.SetActive(false);
            explosion.transform.position = this.transform.position;
            GuiManager.instance.GameOverMethod();
            gameObject.SetActive(false);
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            ReduceLife();
            other.GetComponent<Damage>().reduceLife();
        }
        if (other.CompareTag("Civil"))
        {
            ReduceLife();
            other.GetComponent<CivilBehavior>().reduceLife();
        }
        if (other.CompareTag("Tree"))
        {
            ReduceLife();
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            ReduceLife();
        }

    }
    public void NitroButton()
    {
        if (!(nitro <= 3))
        {
            nitroOn = true;
        }
    }

}
