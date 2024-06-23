using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Asteroid _prefab;

    private Queue<Asteroid> _pool;


    public IEnumerable<Asteroid> PooledObjects => _pool;


    private void Awake()
    {
        _pool = new Queue<Asteroid>();
    }

    public Asteroid GetObject()
    {
        if (_pool.Count == 0)
        {
            Asteroid asteroid = Instantiate(_prefab);
            asteroid.transform.parent = _container;

            return asteroid;
        }

        return _pool.Dequeue();
    }

    public void PutObject(Asteroid asteroid)
    {
        _pool.Enqueue(asteroid);
        asteroid.gameObject.SetActive(false);
    }

    private void Reset()
    {
        _pool.Clear();
    }
}
