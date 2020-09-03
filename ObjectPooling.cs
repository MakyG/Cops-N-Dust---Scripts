using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;

    [System.Serializable]
    public class ObjectPoolItems
    {
        public string name;
        public GameObject objectToPool;
        public int amountToPool;
        public bool shouldExpand;
    }

    public List<GameObject> pooledObjects;
    public ObjectPoolItems[] itemsToPool;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();

        foreach(ObjectPoolItems item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.name = item.name;
                obj.transform.parent = this.transform;
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }
    public GameObject GetPooledObject(string name)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if(pooledObjects[i].activeInHierarchy == false && pooledObjects[i].name == name)
            {
                return pooledObjects[i];
            } 
        }
        foreach (ObjectPoolItems item in itemsToPool)
        {
            if (item.objectToPool.name == name)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.name = item.name;
                obj.transform.parent = this.transform;
                obj.SetActive(false);
                pooledObjects.Add(obj);
                return obj;
            }
        }
        return null;
    }
    public GameObject SpawnPooledObject(string objName)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].name == objName)
            {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItems item in itemsToPool)
        {
            if (item.objectToPool.name == objName)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.name = item.name;
                obj.transform.parent = this.transform;
                obj.SetActive(false);
                pooledObjects.Add(obj);
                return obj;
            }
        }
        return null;
    }
}
