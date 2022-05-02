using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    GameObject p1Win;
    GameObject p2Win;

    private void Start()
    {
        p1Win = GameObject.FindGameObjectWithTag("p1Win");
        p1Win.SetActive(false);
        p2Win = GameObject.FindGameObjectWithTag("p2Win");
        p2Win.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            p1Win.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Player2"))
        {
            p2Win.SetActive(true);
        }
        Time.timeScale = 0;
    }
}
