using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBreak : MonoBehaviour
{
    public GameObject explosion;

    private void OnCollisionEnter(Collision other)
    {
        GameObject explosion = ObjectPooling.instance.GetPooledObject("Explosion");
        explosion.SetActive(true);
        explosion.transform.position = this.transform.position;
        gameObject.SetActive(false);
    }
}
