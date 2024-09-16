using UnityEngine;

public class ShipMover : MonoBehaviour
{
    [SerializeField] Transform lakeTransform; 
    [SerializeField] float riseSpeed = 0.5f; 

    bool isRising = false; 

    void Update()
    {
        if (isRising)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = lakeTransform.position.y; 
            transform.position = Vector3.Lerp(transform.position, newPosition, riseSpeed * Time.deltaTime);
        }
    }

    public void StartRising()
    {
        isRising = true;
    }

    public void StopRising()
    {
        isRising = false;
    }
}
