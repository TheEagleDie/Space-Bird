using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
    public event Action PlayerDeath;

    private PlayerCollisionHandler _collisionHandler;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
    }
    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }
    private void Awake()
    {
        Construct();
    }
    private void Construct()
    {
        _collisionHandler = GetComponent<PlayerCollisionHandler>();
    }
    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Asteroid || interactable is Ground)
        {
            PlayerDeath?.Invoke();
        }
        else if (interactable is ScoreZone)
        {
            _scoreCounter.Add();
        }
    }


}
