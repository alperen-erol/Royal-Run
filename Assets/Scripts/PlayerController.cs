using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float clampRange = 3f;
    Rigidbody rb;

    Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float playerXMovement = Math.Clamp(rb.position.x + movement.x * (Time.fixedDeltaTime * playerSpeed), -clampRange, clampRange);
        float playerZMovement = Math.Clamp(rb.position.z + movement.y * (Time.fixedDeltaTime * playerSpeed), -clampRange / 3, clampRange / 3);
        rb.MovePosition(new Vector3(playerXMovement, 0f, playerZMovement));
    }
}
