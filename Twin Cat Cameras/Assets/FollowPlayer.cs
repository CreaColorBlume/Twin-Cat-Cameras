using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform targetObject;

    void LateUpdate()
    {
        transform.position = targetObject.position;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Red") || Input.GetButtonDown("AltRed"))
        {
            transform.Rotate(new Vector3(0.0f, 12.0f, 0.0f));
        }

        if (Input.GetButtonDown("Blue") || Input.GetButtonDown("AltBlue"))
        {
            transform.Rotate(new Vector3(0.0f, -12.0f, 0.0f));
        }
    }

}
