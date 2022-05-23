using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowPlayer : MonoBehaviour
{
    private float _rot = 0.0f;
    private float _minRotation = 12.0f;
    private float _rotationValue = 30.0f;
    private float _maxRotation = 90.0f;

    private float _leftRot = 0.0f;
    private float _altLeftRot = 0.0f;

    private float _rightRot = 0.0f;
    private float _altRightRot = 0.0f;

    public FollowPlayer _otherPlayer;

    public Transform targetObject;
    //private Vector3 _startPos;
    private Quaternion _startRot;
    private AudioSource _as;

    

    public Image rightImage;
    public List<Sprite> _rightSideSprites = new List<Sprite>();

    public Image leftImage;
    public List<Sprite> _leftSideSprites = new List<Sprite>();

    private void Start()
    {
        //_startPos = transform.position;
        _startRot = transform.rotation;
        _as = GetComponent<AudioSource>();

        if(targetObject.CompareTag("Player1"))
        {
            leftImage = GameObject.FindGameObjectWithTag("p1UI").GetComponent<PlayerUIHandler>().left;
            rightImage = GameObject.FindGameObjectWithTag("p1UI").GetComponent<PlayerUIHandler>().right;
        }
        else if (targetObject.CompareTag("Player2"))
        {
            leftImage = GameObject.FindGameObjectWithTag("p2UI").GetComponent<PlayerUIHandler>().left;
            rightImage = GameObject.FindGameObjectWithTag("p2UI").GetComponent<PlayerUIHandler>().right;
        }
    }

    public void IncreaseRotation()
    {
        _minRotation += 6.0f;
        _rotationValue += 10.0f;
    }

    public void Initiate()
    {
        transform.rotation = _startRot;
    }
    void LateUpdate()
    {
        transform.position = targetObject.position;
    }

    private void Update()
    {
        // || Input.GetButtonUp("AltRed")

        _leftRot = ButtonFunction("Red", _leftRot, true);
        _altLeftRot = ButtonFunction("AltRed", _altLeftRot, true);

        _rightRot = ButtonFunction("Blue", _rightRot, false);
        _altRightRot = ButtonFunction("AltBlue", _altRightRot, false);
        UpdateGraphics();
    }

    private void UpdateGraphics()
    {

        int temp = Mathf.FloorToInt(Mathf.Lerp(0, _leftSideSprites.Count, _leftRot / _maxRotation));
        temp = Mathf.FloorToInt(Mathf.Lerp(0, _leftSideSprites.Count, _altLeftRot / _maxRotation));
        leftImage.sprite = _leftSideSprites[temp];
        
        temp = Mathf.FloorToInt(Mathf.Lerp(0, _rightSideSprites.Count, _rightRot / _maxRotation));
        temp = Mathf.FloorToInt(Mathf.Lerp(0, _rightSideSprites.Count, _altRightRot / _maxRotation));
        rightImage.sprite = _rightSideSprites[temp];
        
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
            _rot += Time.deltaTime;

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
                _otherPlayer.RotationFromOtherPlayer(-_rot);
            }
            else
            {
                transform.Rotate(new Vector3(0.0f, rotationVar, 0.0f));
                _otherPlayer.RotationFromOtherPlayer(_rot);
            }

            _rot = 0.0f;
        }
        return 0.0f;
    }

    public void RotationFromOtherPlayer(float rotationValue)
    {
        float rot = _minRotation + rotationValue * _rotationValue;

        if(rotationValue < 0)
        {
            rot *= -1;
        }

        transform.Rotate(new Vector3(0.0f, rot, 0.0f));
    }

}
