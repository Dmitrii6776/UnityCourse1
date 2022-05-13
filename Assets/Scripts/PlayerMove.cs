using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private InputAction movement;

    [Tooltip("speed of ship on x and y")] [SerializeField]
    private float speed = 4f;

    [SerializeField] private float xClump = 4.5f;
    [SerializeField] private float yClump = 2.5f;

    [SerializeField] private float xRotationFactor = -2f;
    [SerializeField] private float yRotationFactor = 5f;

    [SerializeField] private float xMoveRotation = -10f;
    [SerializeField] private float yMoveRotation = 10f;
    [SerializeField] private float zMoveRotation = 10f;

    private bool _isControlEnabled = true;

    private float _xMove, _yMove;

    public InputAction fireAction = new InputAction(binding:"<Mouse>/leftButton");

    [SerializeField] private GameObject[] guns;

    private void OnEnable()
    {
        movement.Enable();
        fireAction.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isControlEnabled)
        {
            PlayerMovement();
            PlayerRotate();
            FireGuns();
        }
        
    }

    void PlayerMovement()
    {
        // Horizontal movement
        _xMove = movement.ReadValue<Vector2>().x;
        var xOfSet = _xMove * speed * Time.deltaTime;
        var newXPosition = transform.localPosition.x + xOfSet;
        var clampXPosition = Mathf.Clamp(newXPosition, -xClump, xClump);
        // Vertical movement
        _yMove = movement.ReadValue<Vector2>().y;
        var yOfSet = _yMove * speed * Time.deltaTime;
        var newYPosition = transform.localPosition.y + yOfSet;
        var clumpYPosition = Mathf.Clamp(newYPosition, -yClump, yClump);

        transform.localPosition = new Vector3(clampXPosition, clumpYPosition, transform.localPosition.z);
    }

    void PlayerRotate()
    {
        var xRotation = transform.localPosition.y * xRotationFactor + _yMove * xMoveRotation;
        var yRotation = transform.localPosition.x * yRotationFactor + _xMove * yMoveRotation;
        var zRotation = _xMove * zMoveRotation;
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation);
    }

    void OnPlayerGameOver()
    {
        print("Control OFF");
        _isControlEnabled = false;
    }

    void FireGuns()
    {
        if (fireAction.phase == InputActionPhase.Started)
        {
            ActiveGuns();
        }
        
      
        
    }

    void ActiveGuns()
    {
        foreach (var gun in guns)
        {
            gun.SetActive(true);
        }
    }

    void DeactiveGuns()
    {
        foreach (var gun in guns)
        {
            gun.SetActive(false);
        }
    }
}