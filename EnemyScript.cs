using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float speed, rotatingSpeed = 0;

    private GameObject target;
    private Rigidbody myBody;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            return;
        }
        Vector3 pointTarget = transform.position - target.transform.position;
        pointTarget.Normalize();

        float value = Vector3.Cross(pointTarget, transform.forward).y;

        myBody.angularVelocity = rotatingSpeed * value * new Vector3(0, 1, 0);
        myBody.velocity = transform.forward * speed;
    }
}
