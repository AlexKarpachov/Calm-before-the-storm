using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float gravity = -9.81f; 
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] float gravitySpeed;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Animator animator;
    [SerializeField] CharacterController controller;

    Vector3 velocity;
    bool isGrounded;
    int isWalkingHash;

    private void Start()
    {
        isWalkingHash = Animator.StringToHash("isRunning");
    }

    void Update()
    {
        PlayerMovements();
    }

    void PlayerMovements()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * moveZ + right * moveX).normalized;

        controller.Move(moveDirection * playerSpeed * Time.deltaTime);
        velocity.y += gravity * gravitySpeed * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            animator.SetBool(isWalkingHash, true);
        }
        else
        {
            animator.SetBool(isWalkingHash, false);
        }
    }
}
