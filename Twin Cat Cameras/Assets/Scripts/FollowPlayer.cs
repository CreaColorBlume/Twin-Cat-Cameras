using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private float _minRotation = 12.0f;
    private float _rotationValue = 30.0f;
    private float _maxRotation = 90.0f;

    private float _redRot = 0.0f;
    private float _altRedRot = 0.0f;

    private float _blueRot = 0.0f;
    private float _altBlueRot = 0.0f;


    public Transform targetObject;
    //private Vector3 _startPos;
    private Quaternion _startRot;
    private AudioSource _as;

    private void Start()
    {
        //_startPos = transform.position;
        _startRot = transform.rotation;
        _as = GetComponent<AudioSource>();

    }

    public void IncreaseRotation()
    {
        _minRotation += 6.0f;
        _rotationValue += 10.0f;
    }

    public void Initiate()
    {
        //transform.position = _startPos;
        transform.rotation = _startRot;
    }
    void LateUpdate()
    {
        transform.position = targetObject.position;
    }

    private void Update()
    {
        // || Input.GetButtonUp("AltRed")

        _redRot = ButtonFunction("Red", _redRot, true);
        _altRedRot = ButtonFunction("AltRed", _altRedRot, true);

        _blueRot = ButtonFunction("Blue", _blueRot, false);
        _altBlueRot = ButtonFunction("AltBlue", _altBlueRot, false);

    }

    private float ButtonFunction(string Button, float rotationVar, bool pos)
    {
        if (Input.GetButtonDown(Button))
        {
            _as.Play();
            return _minRotation;
        }
        else if (Input.GetButton(Button))
        {
           
            if((rotationVar + (Time.deltaTime * _rotationValue)) > _maxRotation)
            {

                _as.Play();
                _as.volume = 0.5f;
                _as.pitch = 0;

                return -5.0f;
                /*if (!pos)
                {
                    transform.Rotate(new Vector3(0.0f, -_maxRotation, 0.0f));
                }
                else
                {
                    transform.Rotate(new Vector3(0.0f, _maxRotation, 0.0f));
                }
                */
                
            }


            _as.volume = Mathf.Lerp(0.5f, 1, rotationVar / _maxRotation);
            _as.pitch = Mathf.Lerp(1, 2, rotationVar / _maxRotation);

            return rotationVar += Time.deltaTime * _rotationValue;
        }
        else if (Input.GetButtonUp(Button))
        {
            _as.Stop();
            _as.volume = 0;
            _as.pitch = 0;

            if (!pos)
            {
                transform.Rotate(new Vector3(0.0f, -rotationVar, 0.0f));
            }
            else
            {
                transform.Rotate(new Vector3(0.0f, rotationVar, 0.0f));
            }
        }
        return 0.0f;
    }

}
