using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPooler : IPooler
{
    [Inject]
    private Factory _factory;
    [SerializeField]
    private List<GameObject> _pooledObjects;

    public void PreparePool(int amount)
    {
        _pooledObjects = new List<GameObject>();
        GameObject spawnedObject;
        for (int i = 0; i < amount; i++)
        {
            spawnedObject = _factory.Create().gameObject;
            _pooledObjects.Add(spawnedObject);
            spawnedObject.SetActive(false);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }
        return null;
    }
}

public interface IPooler
{
    void PreparePool(int amount);
    GameObject GetObject();
}