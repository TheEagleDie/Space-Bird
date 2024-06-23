using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Update()
    {
        Move();
    }


    private void Move()
    {
        transform.position = new Vector3(_player.position.x, transform.position.y, transform.position.z);
    }
}
