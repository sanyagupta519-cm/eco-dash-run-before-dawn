using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = -9.8f;
    public float jumpHeight = 2f;

    private CharacterController controller;
    private Vector3 velocity;

    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 🎮 INPUT
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // 🚶 MOVE PLAYER
        controller.Move(move * speed * Time.deltaTime);

        // 🎯 ANIMATION (RUN / IDLE)
        float moveSpeed = move.magnitude;
        animator.SetFloat("Speed", moveSpeed);

        // 🧱 GROUND CHECK (FIXED)
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // 🦘 JUMP
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger("jump"); // IMPORTANT: Trigger
        }

        // 🌍 GRAVITY
        velocity.y += gravity * Time.deltaTime;

        // APPLY GRAVITY
        controller.Move(velocity * Time.deltaTime);
    }
}