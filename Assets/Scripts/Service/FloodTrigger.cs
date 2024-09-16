using UnityEngine;

public class FloodTrigger : MonoBehaviour
{
    [SerializeField] ShipMover shipMover;

    bool waterTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lake") && !waterTriggered)
        {
            waterTriggered = true; 
            shipMover.StartRising(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Lake"))
        {
            waterTriggered = false; 
            shipMover.StopRising(); 
        }
    }
}
