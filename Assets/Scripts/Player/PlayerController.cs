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
    int isWalkingHash;
    bool isGrounded;
    bool isCutting = false;
    bool isPickingUp = false;
    bool isMining = false;

    private void Start()
    {
        isWalkingHash = Animator.StringToHash("isRunning");
    }

    void Update()
    {
        PlayerMovements();
        HandleCutting();
        HandlePickingUp();
        HandleMining();
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

    void HandleCutting()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isCutting)
        {
            isCutting = true;
            animator.SetBool("isCutting", true);

        }
        else if (Input.GetKeyUp(KeyCode.C) && isCutting)
        {
            isCutting = false;
            animator.SetBool("isCutting", false);
        }
    }

    void HandlePickingUp()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isPickingUp)
        {
            isPickingUp = true;
            animator.SetBool("isPickingUp", true);

        }
        else if (Input.GetKeyUp(KeyCode.Z) && isPickingUp)
        {
            isPickingUp = false;
            animator.SetBool("isPickingUp", false);
        }
    }

    void HandleMining()
    {
        if (Input.GetKeyDown(KeyCode.X) && !isMining)
        {
            isMining = true;
            animator.SetBool("isIronMining", true);

        }
        else if (Input.GetKeyUp(KeyCode.X) && isMining)
        {
            isMining = false;
            animator.SetBool("isIronMining", false);
        }
    }

}
