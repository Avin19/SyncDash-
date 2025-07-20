using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject pfGameObject;
    [SerializeField] private int initialSize = 10;

    private Queue<GameObject> pool = new();

    void Start()
    {
        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = Instantiate(pfGameObject, transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject Get()
    {
        if (pool.Count == 0)
        {
            GameObject obj = Instantiate(pfGameObject, transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
        GameObject pooledObj = pool.Dequeue();
        pooledObj.SetActive(true);
        return pooledObj;
    }

    public void ReturnToPool(GameObject Obj)
    {
        Obj.SetActive(false);
        pool.Enqueue(Obj);
    }

}
