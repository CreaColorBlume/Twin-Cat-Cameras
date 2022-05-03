using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeUps : MonoBehaviour
{
    private Animator _ani;

    // Start is called before the first frame update
    void Start()
    {
        _ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _ani.SetBool("_ifHoldingRightWhite", true);
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            _ani.SetBool("_ifHoldingRightWhite", false);
        }


    }
}
