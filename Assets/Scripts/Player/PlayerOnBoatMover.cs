using UnityEngine;

public class PlayerOnBoatMover : MonoBehaviour
{
    [SerializeField] Transform targetPosition;
    [SerializeField] GameObject FoodCollectPanel;
    [SerializeField] CharacterController characterController;

    public static bool playerIsOnBoat = false;

    void Update()
    {
        if (playerIsOnBoat && targetPosition != null)
        {
            Vector3 newPosition = targetPosition.position;
            characterController.enabled = false; 
            transform.position = newPosition;
            characterController.enabled = true;  
        }
    }

    public void OnBoatMover()
    {
        if (targetPosition != null)
        {
            FoodCollectPanel.SetActive(false);

            if (characterController != null)
            {
                Vector3 moveDirection = targetPosition.position - transform.position;
                characterController.Move(moveDirection); 
                playerIsOnBoat = true;

                if (!Countdown.floodStarted)
                {
                    Time.timeScale = 4f;
                }
            }
            
        }
    }
}

