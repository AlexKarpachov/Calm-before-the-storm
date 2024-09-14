using UnityEngine;

public class ResourceTitleRotation : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform Title;

    float rotationSpeed = 10f;

    void Update()
    {
        Rotation();
    }
    void Rotation()
    {
        Vector3 directionToCamera = mainCamera.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(directionToCamera);
        lookRotation *= Quaternion.Euler(0, 180f, 0);
        Vector3 rotation = Quaternion.Lerp(Title.rotation, lookRotation, Time.unscaledDeltaTime * rotationSpeed).eulerAngles;
        Title.rotation = Quaternion.Euler(rotation);
    }
}
