using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_1_CONTROLLER : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    public bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }
}
