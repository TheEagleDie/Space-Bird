using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action<IInteractable> CollisionDetected;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        DetectCollision(collider);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DetectCollision(collision);
    }

    private void DetectCollision(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<IInteractable>(out IInteractable component))
        {
            //IInteractable interactable = component;
            CollisionDetected?.Invoke(component);
        }
    }
    private void DetectCollision(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IInteractable>(out IInteractable component))
        {
            //IInteractable interactable = component;
            CollisionDetected?.Invoke(component);
        }
    }
}
