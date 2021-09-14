using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayers, playerLayer;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform attackPoint;
    public Text HPText;
    private int attackDamage = 20;

    [SerializeField] private float speed, jumpHeight, gravity, attackRange;
    private float horizontalInput;

    private Vector3 velocity;

    private bool isGrounded;

    public int HP;

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        HP = 100;
    }

    private void Update()
    {
        if (view.IsMine)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            isGrounded = Physics.CheckSphere(transform.position, 0.15f, groundLayers, QueryTriggerInteraction.Ignore);

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
            }

            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("punch");
                Attack();
            }

            controller.Move(Time.deltaTime * velocity);

            anim.SetFloat("speed", horizontalInput);
            anim.SetFloat("verticalSpeed", velocity.y);
            anim.SetBool("isGrounded", isGrounded);
            anim.SetBool("isMoving", horizontalInput != 0);
        }
    }

    private void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);

        foreach (Collider enemy in hitEnemies)
        {
            print("hit " + enemy.name);
            enemy.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, 20);
        }
    }

    [PunRPC]
    public void TakeDamage(int damage)
    {
        HP -= damage;
        HPText.text = HP.ToString();
        print(HP);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
