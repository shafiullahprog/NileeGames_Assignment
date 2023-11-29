using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public List<GameObject> pooledObjects;
    [System.Serializable]
    public class ObjectToPool
    {
        public GameObject objectToPool;
        public int amountToPool;
    }

    public List<ObjectToPool> objectPrefabPools;
    public Dictionary<GameObject, List<GameObject>> objectPools;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        InitializationPooledObject();
    }

    private void InitializationPooledObject()
    {
        objectPools = new Dictionary<GameObject, List<GameObject>>();

        foreach (ObjectToPool otp in objectPrefabPools)
        {
            List<GameObject> pool = new List<GameObject>();

            for (int i = 0; i < otp.amountToPool; i++)
            {
                GameObject obj = Instantiate(otp.objectToPool);
                obj.transform.position = Vector3.one;
                //obj.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                obj.SetActive(false);
                pool.Add(obj);
            }

            objectPools[otp.objectToPool] = pool;
        }
    }
    public GameObject GetPooledObject(GameObject prefab)
    {
        if (objectPools.ContainsKey(prefab))
        {
            foreach (GameObject obj in objectPools[prefab])
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }

            GameObject newObj = Instantiate(prefab);
            objectPools[prefab].Add(newObj);
            return newObj;
        }
        return null;
    }
}
