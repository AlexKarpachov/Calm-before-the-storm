using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed;

    float horizontalAxis;
    float verticalAxis;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); 
        float moveZ = Input.GetAxis("Vertical");   

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        transform.position += move * playerSpeed * Time.deltaTime;
    }
}
