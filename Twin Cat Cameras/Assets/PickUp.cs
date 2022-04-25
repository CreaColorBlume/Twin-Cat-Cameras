using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public enum PickupType
    {
        CameraSwitch,
        PlayerSwitch,
        IncreaseVelocity,
        SlowOpponent,
        Slow,
        IncreaseCameraOpponent,
        IncreaseCameraPlayer
    }

    protected bool player1 = false;
    protected bool player2 = false;
    [SerializeField] private PickupType _type;

    private float _slowTimer = 25.0f;

    private void Start()
    {
        _type = RandomEnumValue<PickupType>();
    }

    static T RandomEnumValue<T>()
    {
        var v = System.Enum.GetValues(typeof(T));
        return (T)v.GetValue(Random.Range(0, v.Length));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            player1 = true;
        }
        else if (other.gameObject.CompareTag("Player2"))
        {
            player2 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            player1 = false;
        }
        else if (other.gameObject.CompareTag("Player2"))
        {
            player2 = false;
        }
    }

    private void Update()
    {
        if ((player1 || player2))
        {
            if (player1 && Input.GetButtonDown("Yellow"))
            {
                PickUpThePickUp("Player1");
            }

            if (player2 && Input.GetButtonDown("AltYellow"))
            {
                PickUpThePickUp("Player2");
            }
        }
    }


    protected void PickUpThePickUp(string playerTag)
    {

        switch (_type)
        {
            case PickupType.CameraSwitch:
                SwitchCamera();
                break;
            case PickupType.PlayerSwitch:
                SwapPlayerLocations();
                break;
            case PickupType.IncreaseVelocity:
                IncreaseVeolcity(playerTag);
                break;
            case PickupType.SlowOpponent:
                SlowOpponent(playerTag);
                break;
            case PickupType.Slow:
                Slow(playerTag);
                break;
            case PickupType.IncreaseCameraOpponent:
                OpponentCamera(playerTag);
                break;
            case PickupType.IncreaseCameraPlayer:
                PlayerCamera(playerTag);
                break;

            default:
                break;

        }

        Destroy(gameObject);
    }


    private void SwitchCamera()
    {
        Camera cam1 = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Camera cam2 = GameObject.FindGameObjectWithTag("MainCamera2").GetComponent<Camera>();

        Rect _cam1Rect = cam1.rect;
        cam1.rect = cam2.rect;
        cam2.rect = _cam1Rect;
    }
    private void SwapPlayerLocations()
    {
        Transform player1 = GameObject.FindGameObjectWithTag("Player1").transform;
        Transform player2 = GameObject.FindGameObjectWithTag("Player2").transform;

        Vector3 _player1Location = player1.position;
        Vector3 _player2Location = player2.position;

        player1.position = _player2Location;
        player2.position = _player1Location;
    }
    private void IncreaseVeolcity(string playerTarget)
    {
        playerTwo_movement targetPlayer = GameObject.FindGameObjectWithTag(playerTarget).GetComponent<playerTwo_movement>();
        targetPlayer.SpeedBoost();
    }
    private void Slow(string playerTarget)
    {
        playerTwo_movement targetPlayer = GameObject.FindGameObjectWithTag(playerTarget).GetComponent<playerTwo_movement>();
        targetPlayer.Slow(_slowTimer);
    }
    private void SlowOpponent(string playerTarget)
    {
        if (playerTarget == "Player1")
        {
           GameObject.FindGameObjectWithTag("Player2").GetComponent<playerTwo_movement>().Slow(_slowTimer);
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player1").GetComponent<playerTwo_movement>().Slow(_slowTimer);
        }
    }
    private void PlayerCamera(string playerTarget)
    {
        if (playerTarget == "Player1")
        {
            GameObject.FindGameObjectWithTag("MainCamera").transform.parent.GetComponent<FollowPlayer>().IncreaseRotation();
        }
        else
        {
            GameObject.FindGameObjectWithTag("MainCamera2").transform.parent.GetComponent<FollowPlayer>().IncreaseRotation();
        }
    }
    private void OpponentCamera(string playerTarget)
    {
        if (playerTarget == "Player1")
        {
            GameObject.FindGameObjectWithTag("MainCamera2").transform.parent.GetComponent<FollowPlayer>().IncreaseRotation();
        }
        else
        {
            GameObject.FindGameObjectWithTag("MainCamera").transform.parent.GetComponent<FollowPlayer>().IncreaseRotation();
        }
    }
}
