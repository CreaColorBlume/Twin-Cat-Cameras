using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTwo_movement : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;
    private Vector3 _movementVector = new Vector3();
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _movementVector = Vector3.zero;

        if (Input.GetButton("AltRight"))
        {
            _movementVector += Vector3.right;
        }
        else
        {
            if(_rb.velocity.x < 0)
            {
           //     _movementVector += Vector3.right;
            }
        }

        if (Input.GetButton("AltLeft"))
        {
            _movementVector += Vector3.left;
        }
        else
        {
            if (_rb.velocity.x > 0)
            {
           //     _movementVector += Vector3.left;
            }
        }

        if (Input.GetButton("AltUp"))
        {
            _movementVector += Vector3.forward;
        }
        else
        {
            if (_rb.velocity.z < 0)
            {
            //    _movementVector += Vector3.forward;
            }
        }

        if (Input.GetButton("AltDown"))
        {
            _movementVector += Vector3.back;
        }
        else
        {
            if (_rb.velocity.z > 0)
            {
           //     _movementVector += Vector3.back;
            }
        }

        _movementVector = Vector3.ClampMagnitude(_movementVector, 1.0f);
        _movementVector *= _speed;
        _rb.AddForce(_movementVector);
    }
}
