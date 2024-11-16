using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IS_DOOR_OPEN : MonoBehaviour
{
    public GameObject door;
    Renderer shapeRenderer;

    // Start is called before the first frame update
    void Start()
    {
        shapeRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (door.GetComponent<DoorController>().enabled)
        {
            shapeRenderer.material.color = Color.green;
        }
        else
        {
            shapeRenderer.material.color = Color.red;
        }
    }
}
