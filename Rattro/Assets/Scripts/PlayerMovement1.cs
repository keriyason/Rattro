using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed; // Movement Speed of Player

    public float groundDrag; // Ground Friction

    [Header ("Ground Check")]
    public float playerHeight; // Height of the Player used for Ground
    public LayerMask whatIsGround; // Define Layer 
    bool grounded; // Determine whether or not the player is touching the ground

    public Transform orientation;

    // Player Controls WASD or Arrow Keys
    float horizontalInput; 
    float verticalInput;

    //Direction Player Moves in
    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        //Rididbody Component
        rb = GetComponent<Rigidbody>();
        //Keeps Rigidbody from moving
        rb. freezeRotation = true;
  
    }
    void Update()
    {
        // Ground Check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        // Handle Drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }
    private void FixedUpdate()
    {
      MovePlayer();
    }
    void MyInput()
    {
        // Movement Inputs 
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }
    void MovePlayer()
    {
        //Movement direction relative to orientation of Player
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
