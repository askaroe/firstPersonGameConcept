using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;
    private float _speed = 12f;

    private Vector3 _velocity;
    [SerializeField]
    private float _gravity = -9.8f;

    [SerializeField]
    private Transform _groundCheck;

    private float _groundDistance = 0.4f;
    
    [SerializeField]
    private LayerMask _groundMask;

    private bool _isGrounded;
    [SerializeField]
    private float _jumpForce = 3f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");    
        float z = Input.GetAxis("Vertical");

        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if(_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        if(Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = _jumpForce;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        _controller.Move(move * _speed * Time.deltaTime);

        _velocity.y += _gravity * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);

    }
}
