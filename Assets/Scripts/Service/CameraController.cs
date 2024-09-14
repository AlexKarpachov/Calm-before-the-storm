using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset = new Vector3(0, 10f, -5f);
    [SerializeField] float rotationSpeed = 100f;

    float currentRotationY = 0f;

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");

        currentRotationY += mouseX * rotationSpeed * Time.deltaTime;

        Quaternion cameraRotation = Quaternion.Euler(0f, currentRotationY, 0f);

        Vector3 targetPosition = player.position + cameraRotation * offset;

        transform.position = targetPosition;
        transform.LookAt(player); 
    }
}
