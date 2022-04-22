using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTwo_movement : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;
    private Vector3 _movementVector = new Vector3();
    private Rigidbody _rb;
    [SerializeField] private bool _playerOne = true;
    private string _cameraTag = "MainCamera";
    [SerializeField] private Controls _controlObject = new Controls();

    [System.Serializable]
    private class Controls
    {
        public string _rightButton;
        public string _leftButton;
        public string _forwardButton;
        public string _backButton;
    }




    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_playerOne)
        {
            _cameraTag = "MainCamera";
            _controlObject._rightButton = "Right";
            _controlObject._leftButton = "Left";
            _controlObject._forwardButton = "Up";
            _controlObject._backButton = "Down";
        }
        else
        {
            _cameraTag = "MainCamera2";
            _controlObject._rightButton = "AltRight";
            _controlObject._leftButton = "AltLeft";
            _controlObject._forwardButton = "AltUp";
            _controlObject._backButton = "AltDown";
        }

    }

    // Update is called once per frame
    void Update()
    {
        _movementVector = Vector3.zero;

        if (Input.GetButton(_controlObject._rightButton))
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

        if (Input.GetButton(_controlObject._leftButton))
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

        if (Input.GetButton(_controlObject._forwardButton))
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

        if (Input.GetButton(_controlObject._backButton))
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
        _movementVector = GameObject.FindGameObjectWithTag(_cameraTag).transform.TransformDirection(_movementVector);

        _movementVector = Vector3.ClampMagnitude(_movementVector, 1.0f);
        _movementVector *= _speed;
        _rb.AddForce(_movementVector);
    }
}
