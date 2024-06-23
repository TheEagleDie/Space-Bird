using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    
    [SerializeField] private int _amountToPool;

    public List<GameObject> PooledObjects;

    private void OnEnable()
    {
        Game.GameRestarted += OnGameRestarted;
    }
    private void OnDisable()
    {
        Game.GameRestarted -= OnGameRestarted;
    }
    private void Awake()
    {
        Construct();
    }
    private void Construct()
    {
        PooledObjects = new List<GameObject>();

        GameObject prefabTemplate;
        for(int i = 0; i < _amountToPool; i++)
        {
            prefabTemplate = Instantiate(_prefab);
            prefabTemplate.SetActive(false);
            PooledObjects.Add(prefabTemplate);
        }
    }

    public GameObject GetObject()
    {
        for(int i = 0; i < _amountToPool; i++)
        {
            if (!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }
        return null;

    }
    public void PutObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    private void OnGameRestarted()
    {
        foreach (GameObject gameObject in PooledObjects)
        {
            if (gameObject.activeInHierarchy)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void Reset()
    {
        PooledObjects.Clear();
    }

}
