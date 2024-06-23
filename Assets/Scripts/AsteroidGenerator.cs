using System.Collections;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private MyObjectPool _pool;
    [SerializeField] private float _zOrder;

    private void Start()
    {
        StartCoroutine(GenerateAsteroids());
    }

    private IEnumerator GenerateAsteroids()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();

            yield return wait;
        }
    }
    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, _zOrder);

        GameObject asteroids = _pool.GetObject();
        if (asteroids != null)
        {
            asteroids.transform.position = spawnPoint;
            asteroids.SetActive(true);
        }
    }

}
