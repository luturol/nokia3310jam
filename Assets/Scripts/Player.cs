using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody2D rigid;

    [SerializeField] private float speed = 10f;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Awake()
    {
        playerInput = new PlayerInput();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Movement(Vector2 moveInput)
    {
        if (moveInput.x != 0 || moveInput.y != 0)
        {

            if (moveInput.x < 0)
                spriteRenderer.flipX = true;
            else
                spriteRenderer.flipX = false;

            animator.SetInteger("Walking", 1);
        }
        else
        {
            animator.SetInteger("Walking", 0);
        }

        rigid.MovePosition(rigid.position + moveInput * speed * Time.fixedDeltaTime);
        rigid.velocity = moveInput * speed;
    }

    void OnEnable()
    {
        playerInput.Enable();
    }

    void OnDisable()
    {
        playerInput.Disable();
    }

    void FixedUpdate()
    {
        Movement(playerInput.Movement.Move.ReadValue<Vector2>());
    }
}
