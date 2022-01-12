using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool SharedInstance;
    public GameObject prefab;
    public List<GameObject> pooledObject;

    public int amountToPool;

    private void Awake() {
        if(SharedInstance == null){

            SharedInstance = this;
        }else{
            Debug.LogError("YA HAY OTRO POOL EN PANTALLA");
            Destroy(gameObject);
        }
    }

    private void Start() {
        
        pooledObject = new List<GameObject>();
        GameObject tmp;

        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(prefab);
            tmp.SetActive(false);
            pooledObject.Add(tmp);
        }
        
    }


    public GameObject GetFirstPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObject[i].activeInHierarchy)
            {
                return pooledObject[i];
            }
        }

        return null;

    }
}
