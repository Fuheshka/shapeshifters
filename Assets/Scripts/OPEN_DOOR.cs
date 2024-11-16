using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class OPEN_DOOR : MonoBehaviour
{
    public GameObject door; // —сылка на дверь
    public string ball_tag;
    private void OnTriggerEnter(Collider other)
    {
        // ѕровер€ем, что коллайдер принадлежит герою (можете заменить "Player" на тег вашего геро€)
        if (other.CompareTag(ball_tag))
        {
            door.GetComponent<DoorController>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(ball_tag))
        {
            door.GetComponent<DoorController>().enabled = false;
        }
    }
}
