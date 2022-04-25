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
    

    private void Start()
    {
        //_startPos = transform.position;
        _startRot = transform.rotation;
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
            return _minRotation;
        }
        else if (Input.GetButton(Button))
        {
           
            if((rotationVar + (Time.deltaTime * _rotationValue)) > _maxRotation)
            {

                return 0.0f;
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

            return rotationVar += Time.deltaTime * _rotationValue;
        }
        else if (Input.GetButtonUp(Button))
        {
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
