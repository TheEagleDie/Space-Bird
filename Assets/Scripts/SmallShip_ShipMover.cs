using System;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class SmallShip_ShipMover : MonoBehaviour
{
    public event Action VelocityAdded;

    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;


    private void OnEnable()
    {
        GameInput.OnJumped += AddVelocity;
        Game.GameRestarted += ShipReset;
        Game.GameStarted += OnGameStarted;
    }
    private void OnDisable()
    {
        GameInput.OnJumped -= AddVelocity;
        Game.GameRestarted -= ShipReset;
        Game.GameStarted -= OnGameStarted;
    }

    private void Start()
    {
        Construct();
    }
    private void Update()
    {
        CalculateRotation();
    }

    private void Construct()
    {
        _startPosition = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void AddVelocity()
    {
        _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
        transform.rotation = _maxRotation;
        VelocityAdded?.Invoke();
    }
    private void CalculateRotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
    private void ShipReset()
    {
        _rigidbody2D.velocity = new Vector3(0, 0, 0);
        _rigidbody2D.angularVelocity = 0;
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void OnGameStarted()
    {
        AddVelocity();
    }
}
