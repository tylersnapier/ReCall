using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 5f;

    [SerializeField]
    private float _jumpForce = 10f;

    private Rigidbody _rb;

    [SerializeField]
    private bool _isGrounded;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        //Movement

        float moveInput = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(moveInput * _movementSpeed, _rb.velocity.y, 0);

        _rb.velocity = move;

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _jumpForce, 0);

            _isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
}
