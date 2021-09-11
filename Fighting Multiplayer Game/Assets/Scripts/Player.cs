using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator anim;

    [SerializeField] private float speed, jumpHeight, gravity;
    private float horizontalInput;

    private Vector3 velocity;

    private bool isGrounded;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(new Vector3(speed * horizontalInput, 0, 0) * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
            print("jumped");
        }

        if (Input.GetMouseButtonDown(0) && !anim.GetCurrentAnimatorStateInfo(0).IsName("PunchL"))
        {
            anim.SetTrigger("punch");
        }
        controller.Move(Time.deltaTime * velocity);

        anim.SetFloat("speed", horizontalInput);
        anim.SetFloat("verticalSpeed", velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isMoving", horizontalInput != 0 ? true : false);
    }
}
