using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    Rigidbody2D rb;

    //Editable Variables
    [SerializeField]
    [Tooltip("How fast the ship moves")]
    float moveSpeed = 5f;

    //Input System Variables
    private PlayerControls playerControls;
    private InputAction move;
    Vector2 moveDirection = Vector2.zero;

    private void Awake()
    {
        //Input System
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        //Input System
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        //Input System
        move.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Reads input from the input system
        moveDirection = move.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        //Updates player velocity based on read input
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
