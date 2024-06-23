using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SmallShip_ShipMover))]
public class PlayerParticle : MonoBehaviour
{
    [SerializeField] private SmallShip_ShipMover _smallShipMover;
    [SerializeField] private ParticleSystem _engineParticle;

    private void OnEnable()
    {
        _smallShipMover.VelocityAdded += OnVelocityAdded;
    }  

    private void OnDisable()
    {
        _smallShipMover.VelocityAdded -= OnVelocityAdded;
    }
    private void Start()
    {
        Construct();
    }
    private void Construct()
    {
        _smallShipMover = GetComponent<SmallShip_ShipMover>();
    }

    private void OnVelocityAdded()
    {
        _engineParticle.Play();
    }
}
