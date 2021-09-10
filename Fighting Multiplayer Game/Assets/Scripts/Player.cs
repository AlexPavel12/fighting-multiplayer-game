using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private CharacterController controller;

    [SerializeField] private float speed, jumpHeight, gravity;

    private Vector3 velocity;

    private bool isGrounded;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, 2.1f, groundLayers, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(new Vector3(speed * Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
            print("jumped");
        }

        controller.Move(Time.deltaTime * velocity);
    }
}
