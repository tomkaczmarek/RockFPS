using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _velocity;
    private bool _isGrounded;

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groudDistance = 0.4f;
    public LayerMask groundMask;



    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groudDistance, groundMask);

        if (_isGrounded && _velocity.y <0 )
            _velocity.y = 0.4f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float mouseY = Input.GetAxis("Mouse Y");
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        _velocity.y += gravity * Time.deltaTime;

        controller.Move(_velocity * Time.deltaTime);

        if(Input.GetButton("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

    }
}
