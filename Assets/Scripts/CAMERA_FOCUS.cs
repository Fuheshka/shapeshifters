using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CAMERA_FOCUS : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetCameraPos();
    }
    void SetCameraPos()
    {
        Vector3 middle = (player1.transform.position + player2.transform.position) * 0.5f;

        transform.position = new Vector3(middle.x, middle.y + 13, middle.z - 10);
    }
}
