using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    [SerializeField] private Transform _SpawnPoint1;
    [SerializeField] private Transform _SpawnPoint2;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            collision.transform.position = _SpawnPoint1.transform.position;
            collision.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameObject.FindGameObjectWithTag("MainCamera").transform.parent.GetComponent<FollowPlayer>().Initiate();
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            collision.transform.position = _SpawnPoint2.transform.position;
            collision.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameObject.FindGameObjectWithTag("MainCamera2").transform.parent.GetComponent<FollowPlayer>().Initiate();
        }
    }

}
