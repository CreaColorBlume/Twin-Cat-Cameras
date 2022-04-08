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
}
