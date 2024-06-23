using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    [SerializeField] private InputActions _inputActions;

    public static event Action OnJumped;

    private void Awake()
    {
        Construct();
    }

    private void Construct()
    {
        _inputActions = new InputActions();
        _inputActions.SmallShip.Enable();
        _inputActions.SmallShip.Jump.performed += Jump_Action;
    }

    private void Jump_Action(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        OnJumped?.Invoke();
    }
}
