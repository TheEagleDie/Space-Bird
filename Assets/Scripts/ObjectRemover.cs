using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private MyObjectPool _pool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.transform.parent.TryGetComponent<AsteroidsPrefab>(out AsteroidsPrefab asteroidsPrefab))
        {
            _pool.PutObject(asteroidsPrefab.gameObject);
        }
    }
}
